using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para la gestión de vehículos.
/// </summary>
public class VehiculoService : IVehiculoService
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IArrendatarioRepository _arrendatarioRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor que inicializa una nueva instancia del servicio de vehículos.
    /// </summary>
    /// <param name="vehiculoRepository">Repositorio para realizar operaciones de vehículos.</param>
    /// <param name="propietarioRepository">Repositorio para operaciones de propietarios.</param>
    /// <param name="arrendatarioRepository">Repositorio para operaciones de arrendatarios.</param>
    /// <param name="alquilerRepository">Repositorio para operaciones de alquileres.</param>
    /// <param name="unitOfWork">Unidad de trabajo para la ejecución de operaciones transaccionales.</param>
    
    public VehiculoService(IVehiculoRepository vehiculoRepository, IPropietarioRepository propietarioRepository, IUnitOfWork unitOfWork, IAlquilerRepository alquilerRepository, IArrendatarioRepository arrendatarioRepository)
    {
        _vehiculoRepository = vehiculoRepository;
        _propietarioRepository = propietarioRepository;
        _alquilerRepository = alquilerRepository;
        _arrendatarioRepository = arrendatarioRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Obtiene una lista de todos los vehículos de manera asincrónica.
    /// </summary>
    /// <returns>Una lista de vehículos.</returns>
    
    public async Task<IEnumerable<Vehiculo>> ListAsync()
    {
        return await _vehiculoRepository.ListAsync();
    }

    /// <summary>
    /// Guarda un vehículo en la base de datos de forma asincrónica.
    /// </summary>
    /// <param name="vehiculo">Datos del vehículo a guardar.</param>
    /// <returns>Una respuesta con el resultado de la operación de guardado.</returns>
    
    public async Task<IEnumerable<Vehiculo>> ListByPropietarioIdAsync(int propietarioId)
    {
        return await _vehiculoRepository.FindByPropietarioIdAsync(propietarioId);
    }

    /// <summary>
    /// Actualiza un vehículo existente en la base de datos de forma asincrónica.
    /// </summary>
    /// <param name="vehiculoId">Identificador del vehículo a actualizar.</param>
    /// <param name="vehiculo">Datos actualizados del vehículo.</param>
    /// <returns>Una respuesta con el resultado de la operación de actualización.</returns>
    
    public async Task<IEnumerable<Vehiculo>> ListByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _vehiculoRepository.FindByArrendatarioIdAsync(arrendatarioId);
    }

     /// <summary>
    /// Elimina un vehículo de la base de datos de forma asincrónica.
    /// </summary>
    /// <param name="vehiculoId">Identificador del vehículo a eliminar.</param>
    /// <returns>Una respuesta con el resultado de la operación de eliminación.</returns>
    public async Task<IEnumerable<Vehiculo>> ListByAlquilerIdAsync(int alquilerId)
    {
        return await _vehiculoRepository.FindByAlquilerIdAsync(alquilerId);
    }

    public async Task<VehiculoResponse> SaveAsync(Vehiculo vehiculo)
    {
        try
        {
            // Asignar las entidades relacionadas
            vehiculo.Propietario = await _propietarioRepository.FindByIdAsync(vehiculo.PropietarioId);
            
            await _vehiculoRepository.AddAsync(vehiculo);
            await _unitOfWork.CompleteAsync();
            return new VehiculoResponse(vehiculo);
        }
        catch (Exception e)
        {
            return new VehiculoResponse($"An error occurred while saving the vehiculo: {e.Message}");
        }
    }

    public async Task<VehiculoResponse> UpdateAsync(int vehiculoId, Vehiculo vehiculo)
    {
        var existingVehiculo = await _vehiculoRepository.FindByIdAsync(vehiculoId);
        if (existingVehiculo == null)
            return new VehiculoResponse("Vehiculo not found.");
        
        
        
        // Actualiza las propiedades simples del vehículo con los valores del objeto vehiculo
        existingVehiculo.Marca = UpdateIfValid(existingVehiculo.Marca, vehiculo.Marca);
        existingVehiculo.Modelo = UpdateIfValid(existingVehiculo.Modelo, vehiculo.Modelo);
        existingVehiculo.VelocidadMax = UpdateIfValid(existingVehiculo.VelocidadMax, vehiculo.VelocidadMax);
        existingVehiculo.Consumo = UpdateIfValid(existingVehiculo.Consumo, vehiculo.Consumo);
        existingVehiculo.Dimensiones = UpdateIfValid(existingVehiculo.Dimensiones, vehiculo.Dimensiones);
        existingVehiculo.Peso = UpdateIfValid(existingVehiculo.Peso, vehiculo.Peso);
        existingVehiculo.Clase = UpdateIfValid(existingVehiculo.Clase, vehiculo.Clase);
        existingVehiculo.Transmision = UpdateIfValid(existingVehiculo.Transmision, vehiculo.Transmision);
        existingVehiculo.Tiempo = UpdateIfValid(existingVehiculo.Tiempo, vehiculo.Tiempo);
        existingVehiculo.TipoTiempo = UpdateIfValid(existingVehiculo.TipoTiempo, vehiculo.TipoTiempo);
        existingVehiculo.CostoAlquiler = UpdateIfValid(existingVehiculo.CostoAlquiler, vehiculo.CostoAlquiler);
        existingVehiculo.LugarRecojo = UpdateIfValid(existingVehiculo.LugarRecojo, vehiculo.LugarRecojo);
        existingVehiculo.UrlImagen = UpdateIfValid(existingVehiculo.UrlImagen, vehiculo.UrlImagen);
        existingVehiculo.ContratoAlquilerPdf = UpdateIfValid(existingVehiculo.ContratoAlquilerPdf, vehiculo.ContratoAlquilerPdf);
        existingVehiculo.EstadoRenta = UpdateIfValid(existingVehiculo.EstadoRenta, vehiculo.EstadoRenta);
        
        try
        {
            // Actualiza las propiedades de navegación del vehículo existente
            existingVehiculo.ArrendatarioId = vehiculo.ArrendatarioId;
            existingVehiculo.AlquilerId = vehiculo.AlquilerId;
            
            _vehiculoRepository.Update(existingVehiculo);
            await _unitOfWork.CompleteAsync();
            return new VehiculoResponse(existingVehiculo);
        }
        catch (Exception e)
        {
            return new VehiculoResponse($"An error occurred while updating the vehiculo: {e.Message}");
        }
    }

    public async Task<VehiculoResponse> DeleteAsync(int vehiculoId)
    {
        var existingVehiculo = await _vehiculoRepository.FindByIdAsync(vehiculoId);
        if (existingVehiculo == null)
            return new VehiculoResponse("Vehiculo not found.");

        try
        {
            _vehiculoRepository.Remove(existingVehiculo);
            await _unitOfWork.CompleteAsync();
            return new VehiculoResponse(existingVehiculo);
        }
        catch (Exception e)
        {
            return new VehiculoResponse($"An error occurred while deleting the vehiculo: {e.Message}");
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