using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para gestionar las operaciones CRUD de alquileres.
/// </summary>
public class AlquilerService : IAlquilerService
{
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IArrendatarioRepository _arrendatarioRepository;
    private readonly ISolicitudRepository _solicitudRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    // Declaraciones de los repositorios y unidad de trabajo (UnitOfWork)

    /// <summary>
    /// Inicializa una nueva instancia del servicio de alquileres, inyectando las dependencias necesarias.
    /// </summary>
    /// <param name="alquilerRepository">Repositorio para operaciones de alquiler.</param>
    /// <param name="vehiculoRepository">Repositorio para operaciones de vehículo.</param>
    /// <param name="propietarioRepository">Repositorio para operaciones de propietario.</param>
    /// <param name="arrendatarioRepository">Repositorio para operaciones de arrendatario.</param>
    /// <param name="solicitudRepository">Repositorio para operaciones de solicitud.</param>
    /// <param name="unitOfWork">Unidad de trabajo para operaciones que involucran múltiples repositorios.</param>
    
    public AlquilerService(IAlquilerRepository alquilerRepository, IVehiculoRepository vehiculoRepository, IPropietarioRepository propietarioRepository, IArrendatarioRepository arrendatarioRepository, ISolicitudRepository solicitudRepository, IUnitOfWork unitOfWork)
        {
            _alquilerRepository = alquilerRepository;
            _vehiculoRepository = vehiculoRepository;
            _propietarioRepository = propietarioRepository;
            _arrendatarioRepository = arrendatarioRepository;
            _solicitudRepository = solicitudRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista asincrónica de todos los alquileres.
        /// </summary>
        /// <returns>Una lista de instancias de Alquiler.</returns>
        public async Task<IEnumerable<Alquiler>> ListAsync()
        {
            return await _alquilerRepository.ListAsync();
        }

        public async Task<IEnumerable<Alquiler>> ListByVehiculoIdAsync(int vehiculoId)
        {
            return await _alquilerRepository.FindByVehiculoIdAsync(vehiculoId);
        }

        public async Task<IEnumerable<Alquiler>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _alquilerRepository.FindByPropietarioIdAsync(propietarioId);
        }

        public async Task<IEnumerable<Alquiler>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _alquilerRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        /// <summary>
        /// Guarda un alquiler de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="alquiler">Datos del alquiler a guardar.</param>
        /// <returns>Respuesta de la operación con el alquiler guardado o un error.</returns>
        public async Task<AlquilerResponse> SaveAsync(Alquiler alquiler)
        {
            try
            {
                Console.WriteLine($"VehiculoId antes: {alquiler.VehiculoId}");
                Console.WriteLine($"PropietarioId antes: {alquiler.PropietarioId}");
                Console.WriteLine($"ArrendatarioId antes: {alquiler.ArrendatarioId}");
                
                // Asignar las entidades relacionadas
                alquiler.Vehiculo = await _vehiculoRepository.FindByIdAsync(alquiler.VehiculoId);
                alquiler.Propietario = await _propietarioRepository.FindByIdAsync(alquiler.PropietarioId);
                alquiler.Arrendatario = await _arrendatarioRepository.FindByIdAsync(alquiler.ArrendatarioId);
                
                // Imprimir los IDs después de asignar las entidades relacionadas
                Console.WriteLine($"VehiculoId después: {alquiler.VehiculoId}");
                Console.WriteLine($"PropietarioId después: {alquiler.PropietarioId}");
                Console.WriteLine($"ArrendatarioId después: {alquiler.ArrendatarioId}");
                
                await _alquilerRepository.AddAsync(alquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(alquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while saving the alquiler: {e.Message}");
            }
        }

        /// <summary>
        /// Actualiza un alquiler existente de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="alquilerId">Identificador del alquiler a actualizar.</param>
        /// <param name="alquiler">Datos del alquiler con las actualizaciones.</param>
        /// <returns>Respuesta de la operación con el alquiler actualizado o un error.</returns>
        public async Task<AlquilerResponse> UpdateAsync(int alquilerId, Alquiler alquiler)
        {
            var existingAlquiler = await _alquilerRepository.FindByIdAsync(alquilerId);
            if (existingAlquiler == null)
                return new AlquilerResponse("Alquiler not found.");

            existingAlquiler.Estado = UpdateIfValid(existingAlquiler.Estado, alquiler.Estado);
            existingAlquiler.Fecha_inicio = UpdateIfValid(existingAlquiler.Fecha_inicio, alquiler.Fecha_inicio);
            existingAlquiler.Fecha_fin = UpdateIfValid(existingAlquiler.Fecha_fin, alquiler.Fecha_fin);
            existingAlquiler.Costo_total = UpdateIfValid(existingAlquiler.Costo_total, alquiler.Costo_total);

            try
            {
                // Actualiza las propiedades de navegación del vehículo existente
                existingAlquiler.ArrendatarioId = alquiler.ArrendatarioId;
                existingAlquiler.PropietarioId = alquiler.PropietarioId;
                existingAlquiler.VehiculoId = alquiler.VehiculoId;
                
                _alquilerRepository.Update(existingAlquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(existingAlquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while updating the alquiler: {e.Message}");
            }
        }

        /// <summary>
        /// Elimina un alquiler de manera asincrónica de la base de datos.
        /// </summary>
        /// <param name="alquilerId">Identificador del alquiler a eliminar.</param>
        /// <returns>Respuesta de la operación con el alquiler eliminado o un error.</returns>
        public async Task<AlquilerResponse> DeleteAsync(int alquilerId)
        {
            var existingAlquiler = await _alquilerRepository.FindByIdAsync(alquilerId);
            if (existingAlquiler == null)
                return new AlquilerResponse("Alquiler not found.");

            try
            {
                _alquilerRepository.Remove(existingAlquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(existingAlquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while deleting the alquiler: {e.Message}");
            }
        }
        
        private bool IsValidNumeric(int? value)
        {
            return value.HasValue && value.Value != 0;
        }
    
        // Método de utilidad para actualizar si el nuevo valor es válido
        private T UpdateIfValid<T>(T existingValue, T newValue)
        {
            if (IsValidForUpdate(newValue))
            {
                return newValue;
            }

            return existingValue;
        }

        // Método de utilidad para validar si un valor es válido para la actualización
        private bool IsValidForUpdate<T>(T value)
        {
            // Si el tipo es una cadena, verifica que no sea igual a "string"
            if (typeof(T) == typeof(string))
            {
                return value != null && !value.Equals("string");
            }
            // Si el tipo es numérico (en este caso, solo int), verifica que no sea igual a 0
            else if (typeof(T) == typeof(int))
            {
                return !EqualityComparer<T>.Default.Equals(value, default(T));
            }
            // Otros tipos
            else
            {
                return value != null && !value.Equals(default(T));
            }
        }
}