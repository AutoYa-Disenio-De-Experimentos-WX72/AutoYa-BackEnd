using AutoMapper;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Repositories;
using AutoYa_Backend.Security.Domain.Services;
using AutoYa_Backend.Security.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AutoYa_Backend.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IUnitOfWork 
        unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest 
        model)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }
    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task RegisterAsync(RegisterRequest model)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(int id, UpdateRequest model)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}