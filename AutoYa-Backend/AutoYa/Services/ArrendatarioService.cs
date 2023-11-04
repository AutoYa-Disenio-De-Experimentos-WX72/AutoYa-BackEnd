using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class ArrendatarioService : IArrendatarioService
{
    private readonly IArrendatarioRepository _arrendatarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArrendatarioService(IArrendatarioRepository arrendatarioRepository, IUnitOfWork unitOfWork)
        {
            _arrendatarioRepository = arrendatarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Arrendatario>> ListAsync()
        {
            return await _arrendatarioRepository.ListAsync();
        }

        public async Task<ArrendatarioResponse> SaveAsync(Arrendatario arrendatario)
        {
            try
            {
                await _arrendatarioRepository.AddAsync(arrendatario);
                await _unitOfWork.CompleteAsync();
                return new ArrendatarioResponse(arrendatario);
            }
            catch (Exception e)
            {
                return new ArrendatarioResponse($"An error occurred while saving the arrendatario: {e.Message}");
            }
        }

        public async Task<ArrendatarioResponse> UpdateAsync(int id, Arrendatario arrendatario)
        {
            var existingArrendatario = await _arrendatarioRepository.FindByIdAsync(id);
            if (existingArrendatario == null)
                return new ArrendatarioResponse("Arrendatario not found.");

            existingArrendatario.Nombres = arrendatario.Nombres;
            existingArrendatario.Apellidos = arrendatario.Apellidos;
            existingArrendatario.FechaNacimiento = arrendatario.FechaNacimiento;
            existingArrendatario.Telefono = arrendatario.Telefono;
            existingArrendatario.Correo = arrendatario.Correo;
            existingArrendatario.AntecedentesPenalesPdf = arrendatario.AntecedentesPenalesPdf;

            try
            {
                _arrendatarioRepository.Update(existingArrendatario);
                await _unitOfWork.CompleteAsync();
                return new ArrendatarioResponse(existingArrendatario);
            }
            catch (Exception e)
            {
                return new ArrendatarioResponse($"An error occurred while updating the arrendatario: {e.Message}");
            }
        }

        public async Task<ArrendatarioResponse> DeleteAsync(int id)
        {
            var existingArrendatario = await _arrendatarioRepository.FindByIdAsync(id);
            if (existingArrendatario == null)
                return new ArrendatarioResponse("Arrendatario not found.");

            try
            {
                _arrendatarioRepository.Remove(existingArrendatario);
                await _unitOfWork.CompleteAsync();
                return new ArrendatarioResponse(existingArrendatario);
            }
            catch (Exception e)
            {
                return new ArrendatarioResponse($"An error occurred while deleting the arrendatario: {e.Message}");
            }
        }
}