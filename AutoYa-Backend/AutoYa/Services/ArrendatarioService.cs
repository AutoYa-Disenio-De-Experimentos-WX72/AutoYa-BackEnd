using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para gestionar las operaciones CRUD de arrendatarios.
/// </summary>
public class ArrendatarioService : IArrendatarioService
{
    private readonly IArrendatarioRepository _arrendatarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        // Declaraciones de los repositorios y unidad de trabajo (UnitOfWork)
        
        /// <summary>
        /// Inicializa una nueva instancia del servicio de arrendatarios, inyectando las dependencias necesarias.
        /// </summary>
        /// <param name="arrendatarioRepository">Repositorio para operaciones de arrendatario.</param>
        /// <param name="unitOfWork">Unidad de trabajo para operaciones que involucran múltiples repositorios.</param>
        public ArrendatarioService(IArrendatarioRepository arrendatarioRepository, IUnitOfWork unitOfWork)
        {
            _arrendatarioRepository = arrendatarioRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista asincrónica de todos los arrendatarios.
        /// </summary>
        /// <returns>Una lista de instancias de Arrendatario.</returns>
        public async Task<IEnumerable<Arrendatario>> ListAsync()
        {
            return await _arrendatarioRepository.ListAsync();
        }

        /// <summary>
        /// Guarda un arrendatario de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="arrendatario">Datos del arrendatario a guardar.</param>
        /// <returns>Respuesta de la operación con el arrendatario guardado o un error.</returns>
        public async Task<ArrendatarioResponse> SaveAsync(Arrendatario arrendatario)
        {
            try
            {
                var existingArrendatario = await _arrendatarioRepository.FindByEmailAsync(arrendatario.Correo);

                if (existingArrendatario != null)
                {
                    return new ArrendatarioResponse($"Ya existe un arrendatario registrado con el correo electrónico {arrendatario.Correo}.");
                }
                
                await _arrendatarioRepository.AddAsync(arrendatario);
                await _unitOfWork.CompleteAsync();
                return new ArrendatarioResponse(arrendatario);
            }
            catch (Exception e)
            {
                return new ArrendatarioResponse($"An error occurred while saving the arrendatario: {e.Message}");
            }
        }

        /// <summary>
        /// Actualiza un arrendatario existente de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="id">Identificador del arrendatario a actualizar.</param>
        /// <param name="arrendatario">Datos del arrendatario con las actualizaciones.</param>
        /// <returns>Respuesta de la operación con el arrendatario actualizado o un error.</returns>
        public async Task<ArrendatarioResponse> UpdateAsync(int id, Arrendatario arrendatario)
        {
            // Buscar el arrendatario existente por ID
            var existingArrendatario = await _arrendatarioRepository.FindByIdAsync(id);
            if (existingArrendatario == null)
                return new ArrendatarioResponse("Arrendatario not found.");
            
            // Verificar si el nuevo correo electrónico ya existe en la base de datos
            var arrendatarioByEmail = await _arrendatarioRepository.FindByEmailAsync(arrendatario.Correo);
            if (arrendatarioByEmail != null && arrendatarioByEmail.Id != id)
            {
                return new ArrendatarioResponse("Ya existe un arrendatario con este correo electrónico.");
            }
            
            existingArrendatario.Nombres = arrendatario.Nombres;
            existingArrendatario.Apellidos = arrendatario.Apellidos;
            existingArrendatario.FechaNacimiento = arrendatario.FechaNacimiento;
            existingArrendatario.Telefono = arrendatario.Telefono;
            existingArrendatario.Correo = arrendatario.Correo;
            existingArrendatario.AntecedentesPenalesPdf = arrendatario.AntecedentesPenalesPdf;
            existingArrendatario.Contrasenia = arrendatario.Contrasenia;

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


        /// <summary>
        /// Elimina un arrendatario de manera asincrónica de la base de datos.
        /// </summary>
        /// <param name="id">Identificador del arrendatario a eliminar.</param>
        /// <returns>Respuesta de la operación con el arrendatario eliminado o un error.</returns>
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