using AutoMapper;
using AutoYa_Backend.Security.Authorization.Handlers.Interfaces;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Repositories;
using AutoYa_Backend.Security.Domain.Services;
using AutoYa_Backend.Security.Domain.Services.Communication;
using AutoYa_Backend.Security.Exceptions;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Org.BouncyCastle.Asn1.Ocsp;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AutoYa_Backend.Security.Services;

/// <summary>
/// Clase que representa un servicio de usuarios.
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor que inicializa el repositorio de usuarios, la unidad de trabajo, el mapeador y el manejador de JWT.
    /// </summary>
    /// <param name="userRepository">El repositorio de usuarios.</param>
    /// <param name="unitOfWork">La unidad de trabajo.</param>
    /// <param name="mapper">El mapeador.</param>
    /// <param name="jwtHandler">El manejador de JWT.</param>
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }
    
    /// <summary>
    /// Autentica un usuario.
    /// </summary>
    /// <param name="request">La solicitud de autenticación.</param>
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.FirstName}, {user.LastName}, {user.Email}, {user.PasswordHash}");
 
        // validate
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }
 
        Console.WriteLine("Authentication successful. About to generate token");
        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.FirstName}, {response.LastName}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    
    /// <summary>
    /// Obtiene una lista de todos los usuarios de forma asíncrona.
    /// </summary>
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    /// <summary>
    /// Obtiene un usuario por su ID de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    /// <summary>
    /// Registra un nuevo usuario de forma asíncrona.
    /// </summary>
    /// <param name="request">La solicitud de registro.</param>
    public async Task RegisterAsync(RegisterRequest request)
    {
        //Validate
        if (_userRepository.ExistsByEmail(request.Email))
            throw new AppException("Email '" + request.Email + "' is already taken");
        
        // map model to new user object
        var user = _mapper.Map<User>(request);
        
        // hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    /// <summary>
    /// Actualiza un usuario de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    /// <param name="request">La solicitud de actualización.</param>
    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        
        //validate
        if (_userRepository.ExistsByEmail(request.Email)) 
            throw new AppException("Email '" + request.Email + "' is already taken");
            
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    /// <summary>
    /// Elimina un usuario de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
 
        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }

    }
    
    // Métodos auxiliares
    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("Email not found");
        return user;
    }
}