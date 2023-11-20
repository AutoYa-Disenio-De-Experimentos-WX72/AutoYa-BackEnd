using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para la gestión de propietarios en la aplicación.
/// </summary>
public class PropietarioService : IPropietarioService
{
    private readonly IPropietarioRepository _propietarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor que inicializa una nueva instancia del servicio de propietarios.
        /// </summary>
        /// <param name="propietarioRepository">Repositorio para realizar operaciones de propietarios.</param>
        /// <param name="unitOfWork">Unidad de trabajo para la ejecución de operaciones transaccionales.</param>
        public PropietarioService(IPropietarioRepository propietarioRepository, IUnitOfWork unitOfWork)
        {
            _propietarioRepository = propietarioRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista de todos los propietarios de forma asincrónica.
        /// </summary>
        /// <returns>Lista asincrónica de propietarios.</returns>
        public async Task<IEnumerable<Propietario>> ListAsync()
        {
            return await _propietarioRepository.ListAsync();
        }

        public async Task<PropietarioResponse> SaveAsync(Propietario propietario)
        {
            try
            {
                var existingArrendatario = await _propietarioRepository.FindByEmailAsync(propietario.Correo);

                if (existingArrendatario != null)
                {
                    return new PropietarioResponse($"Ya existe un propietario registrado con el correo electrónico {propietario.Correo}.");
                }
                
                await _propietarioRepository.AddAsync(propietario);
                await _unitOfWork.CompleteAsync();
                return new PropietarioResponse(propietario);
            }
            catch (Exception e)
            {
                return new PropietarioResponse($"An error occurred while saving the propietario: {e.Message}");
            }
        }

        /// <summary>
        /// Guarda un nuevo propietario en la base de datos de forma asincrónica.
        /// </summary>
        /// <param name="propietario">Datos del propietario a guardar.</param>
        /// <returns>Respuesta con el resultado de la operación de guardado.</returns>
        public async Task<PropietarioResponse> UpdateAsync(int id, Propietario propietario)
        {
            // Buscar el propietario existente por ID
            var existingPropietario = await _propietarioRepository.FindByIdAsync(id);
            
            if (existingPropietario == null)
                return new PropietarioResponse("Propietario not found.");

            // Verificar si el nuevo correo electrónico ya existe en la base de datos
            var propietarioByEmail = await _propietarioRepository.FindByEmailAsync(propietario.Correo);
            if (propietarioByEmail != null && propietarioByEmail.Id != id)
            {
                return new PropietarioResponse("Ya existe un propietario con este correo electrónico.");
            }
            
            existingPropietario.Nombres = propietario.Nombres;
            existingPropietario.Apellidos = propietario.Apellidos;
            existingPropietario.FechaNacimiento = propietario.FechaNacimiento;
            existingPropietario.Telefono = propietario.Telefono;
            existingPropietario.Correo = propietario.Correo;
            existingPropietario.Contrasenia = propietario.Contrasenia;

            try
            {
                _propietarioRepository.Update(existingPropietario);
                await _unitOfWork.CompleteAsync();
                return new PropietarioResponse(existingPropietario);
            }
            catch (Exception e)
            {
                return new PropietarioResponse($"An error occurred while updating the propietario: {e.Message}");
            }
        }

        /// <summary>
        /// Actualiza un propietario existente en la base de datos de forma asincrónica.
        /// </summary>
        /// <param name="id">Identificador del propietario a actualizar.</param>
        /// <param name="propietario">Datos actualizados del propietario.</param>
        /// <returns>Respuesta con el resultado de la operación de actualización.</returns>
        public async Task<PropietarioResponse> DeleteAsync(int id)
        {
            var existingPropietario = await _propietarioRepository.FindByIdAsync(id);
            if (existingPropietario == null)
                return new PropietarioResponse("Propietario not found.");

            try
            {
                _propietarioRepository.Remove(existingPropietario);
                await _unitOfWork.CompleteAsync();
                return new PropietarioResponse(existingPropietario);
            }
            catch (Exception e)
            {
                return new PropietarioResponse($"An error occurred while deleting the propietario: {e.Message}");
            }
        }
}