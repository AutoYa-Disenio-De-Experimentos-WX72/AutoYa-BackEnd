using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class PropietarioService : IPropietarioService
{
    private readonly IPropietarioRepository _propietarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PropietarioService(IPropietarioRepository propietarioRepository, IUnitOfWork unitOfWork)
        {
            _propietarioRepository = propietarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Propietario>> ListAsync()
        {
            return await _propietarioRepository.ListAsync();
        }

        public async Task<PropietarioResponse> SaveAsync(Propietario propietario)
        {
            try
            {
                await _propietarioRepository.AddAsync(propietario);
                await _unitOfWork.CompleteAsync();
                return new PropietarioResponse(propietario);
            }
            catch (Exception e)
            {
                return new PropietarioResponse($"An error occurred while saving the propietario: {e.Message}");
            }
        }

        public async Task<PropietarioResponse> UpdateAsync(int id, Propietario propietario)
        {
            var existingPropietario = await _propietarioRepository.FindByIdAsync(id);
            if (existingPropietario == null)
                return new PropietarioResponse("Propietario not found.");

            existingPropietario.Nombres = propietario.Nombres;
            existingPropietario.Apellidos = propietario.Apellidos;
            existingPropietario.FechaNacimiento = propietario.FechaNacimiento;
            existingPropietario.Telefono = propietario.Telefono;
            existingPropietario.Correo = propietario.Correo;

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