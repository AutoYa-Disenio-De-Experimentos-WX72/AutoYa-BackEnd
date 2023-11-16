using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class VehiculoService : IVehiculoService
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VehiculoService(IVehiculoRepository vehiculoRepository, IPropietarioRepository propietarioRepository, IUnitOfWork unitOfWork, IAlquilerRepository alquilerRepository)
    {
        _vehiculoRepository = vehiculoRepository;
        _propietarioRepository = propietarioRepository;
        _alquilerRepository = alquilerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Vehiculo>> ListAsync()
    {
        return await _vehiculoRepository.ListAsync();
    }

    public async Task<IEnumerable<Vehiculo>> ListByPropietarioIdAsync(int propietarioId)
    {
        return await _vehiculoRepository.FindByPropietarioIdAsync(propietarioId);
    }

    public async Task<IEnumerable<Vehiculo>> ListByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _vehiculoRepository.FindByArrendatarioIdAsync(arrendatarioId);
    }

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
            vehiculo.Alquiler = await _alquilerRepository.FindByIdAsync(vehiculo.AlquilerId);
            
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

        // Actualiza las propiedades del vehículo con los valores del objeto vehiculo
        existingVehiculo.Marca = vehiculo.Marca;
        existingVehiculo.Modelo = vehiculo.Modelo;
        existingVehiculo.VelocidadMax = vehiculo.VelocidadMax;
        existingVehiculo.Consumo = vehiculo.Consumo;
        existingVehiculo.Dimensiones = vehiculo.Dimensiones;
        existingVehiculo.Peso = vehiculo.Peso;
        existingVehiculo.Clase = vehiculo.Clase;
        existingVehiculo.Transmision = vehiculo.Transmision;
        existingVehiculo.Tiempo = vehiculo.Tiempo;
        existingVehiculo.TipoTiempo = vehiculo.TipoTiempo;
        existingVehiculo.CostoAlquiler = vehiculo.CostoAlquiler;
        existingVehiculo.LugarRecojo = vehiculo.LugarRecojo;
        existingVehiculo.UrlImagen = vehiculo.UrlImagen;
        existingVehiculo.ContratoAlquilerPdf = vehiculo.ContratoAlquilerPdf;
        existingVehiculo.EstadoRenta = vehiculo.EstadoRenta;

        try
        {
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
}