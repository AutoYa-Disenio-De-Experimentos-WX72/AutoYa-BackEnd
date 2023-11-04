using AutoYa_Backend.AutoYa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Alquiler> Alquileres { get; set; }
    public DbSet<Arrendatario> Arrendatarios { get; set; }
    public DbSet<Mantenimiento> Mantenimientos { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuración de la entidad Alquiler
    builder.Entity<Alquiler>()
        .ToTable("Alquileres")
        .HasKey(a => a.Id);
    builder.Entity<Alquiler>()
        .Property(a => a.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Alquiler>()
        .Property(a => a.Estado);
    builder.Entity<Alquiler>()
        .Property(a => a.Fecha_inicio);
    builder.Entity<Alquiler>()
        .Property(a => a.Fecha_fin);
    builder.Entity<Alquiler>()
        .Property(a => a.Costo_total);
    
    // Relaciones de Alquiler
    builder.Entity<Alquiler>()
        .HasOne(a => a.Vehiculo)
        .WithMany()
        .HasForeignKey(a => a.VehiculoId);
    builder.Entity<Alquiler>()
        .HasOne(a => a.Propietario)
        .WithMany()
        .HasForeignKey(a => a.PropietarioId);
    builder.Entity<Alquiler>()
        .HasOne(a => a.Arrendatario)
        .WithMany()
        .HasForeignKey(a => a.ArrendatarioId);
    builder.Entity<Alquiler>()
        .HasOne(a => a.Solicitud)
        .WithMany()
        .HasForeignKey(a => a.SolicitudId);

    // Configuración de la entidad Arrendatario
    builder.Entity<Arrendatario>()
        .ToTable("Arrendatarios")
        .HasKey(a => a.Id);
    builder.Entity<Arrendatario>()
        .Property(a => a.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Arrendatario>()
        .Property(a => a.Nombres);
    builder.Entity<Arrendatario>()
        .Property(a => a.Apellidos);
    builder.Entity<Arrendatario>()
        .Property(a => a.FechaNacimiento);
    builder.Entity<Arrendatario>()
        .Property(a => a.Telefono);
    builder.Entity<Arrendatario>()
        .Property(a => a.Correo);
    builder.Entity<Arrendatario>()
        .Property(a => a.AntecedentesPenalesPdf);

    // Relaciones de Arrendatario
    builder.Entity<Arrendatario>()
        .HasMany(a => a.VehiculosAlquilados)
        .WithOne(v => v.Arrendatario)
        .HasForeignKey(v => v.ArrendatarioId);
    builder.Entity<Arrendatario>()
        .HasMany(a => a.Alquileres)
        .WithOne(a => a.Arrendatario)
        .HasForeignKey(a => a.ArrendatarioId);
    builder.Entity<Arrendatario>()
        .HasMany(a => a.Mantenimientos)
        .WithOne(m => m.Arrendatario)
        .HasForeignKey(m => m.ArrendatarioId);
    builder.Entity<Arrendatario>()
        .HasMany(a => a.Notificaciones)
        .WithOne(n => n.Arrendatario)
        .HasForeignKey(n => n.ArrendatarioId);
    
    // Configuración de la entidad Mantenimiento
    builder.Entity<Mantenimiento>()
        .ToTable("Mantenimientos")
        .HasKey(m => m.Id);
    builder.Entity<Mantenimiento>()
        .Property(m => m.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Mantenimiento>()
        .Property(m => m.TipoProblema);
    builder.Entity<Mantenimiento>()
        .Property(m => m.Titulo);
    builder.Entity<Mantenimiento>()
        .Property(m => m.Descripcion);
    builder.Entity<Mantenimiento>()
        .Property(m => m.UrlImagen);
    
    // Relaciones de Mantenimiento
    builder.Entity<Mantenimiento>()
        .HasOne(m => m.Arrendatario)
        .WithMany()
        .HasForeignKey(m => m.ArrendatarioId);
    builder.Entity<Mantenimiento>()
        .HasOne(m => m.Propietario)
        .WithMany()
        .HasForeignKey(m => m.PropietarioId);

    // Configuración de la entidad Notificacion
    builder.Entity<Notificacion>()
        .ToTable("Notificaciones")
        .HasKey(n => n.Id);
    builder.Entity<Notificacion>()
        .Property(n => n.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Notificacion>()
        .Property(n => n.Body);

    // Relaciones de Notificacion
    builder.Entity<Notificacion>()
        .HasOne(n => n.Propietario)
        .WithMany()
        .HasForeignKey(n => n.PropietarioId);
    builder.Entity<Notificacion>()
        .HasOne(n => n.Arrendatario)
        .WithMany()
        .HasForeignKey(n => n.ArrendatarioId);

    // Configuración de la entidad Propietario
    builder.Entity<Propietario>()
        .ToTable("Propietarios")
        .HasKey(p => p.Id);
    builder.Entity<Propietario>()
        .Property(p => p.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Propietario>()
        .Property(p => p.Nombres);
    builder.Entity<Propietario>()
        .Property(p => p.Apellidos);
    builder.Entity<Propietario>()
        .Property(p => p.FechaNacimiento);
    builder.Entity<Propietario>()
        .Property(p => p.Telefono);
    builder.Entity<Propietario>()
        .Property(p => p.Correo);

    // Relaciones de Propietario
    builder.Entity<Propietario>()
        .HasMany(p => p.Vehiculos)
        .WithOne(v => v.Propietario)
        .HasForeignKey(v => v.PropietarioId);
    builder.Entity<Propietario>()
        .HasMany(p => p.Alquileres)
        .WithOne(a => a.Propietario)
        .HasForeignKey(a => a.PropietarioId);
    builder.Entity<Propietario>()
        .HasMany(p => p.Mantenimientos)
        .WithOne(m => m.Propietario)
        .HasForeignKey(m => m.PropietarioId);
    builder.Entity<Propietario>()
        .HasMany(p => p.Notificaciones)
        .WithOne(n => n.Propietario)
        .HasForeignKey(n => n.PropietarioId);

    // Configuración de la entidad Solicitud
    builder.Entity<Solicitud>()
        .ToTable("Solicitudes")
        .HasKey(s => s.Id);
    builder.Entity<Solicitud>()
        .Property(s => s.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Solicitud>()
        .Property(s => s.Body);

    // Relaciones de Solicitud
    builder.Entity<Solicitud>()
        .HasOne(s => s.Alquiler)
        .WithOne(a => a.Solicitud)
        .HasForeignKey<Solicitud>(s => s.AlquilerId);

    // Configuración de la entidad Vehiculo
    builder.Entity<Vehiculo>()
        .ToTable("Vehiculos")
        .HasKey(v => v.Id);
    builder.Entity<Vehiculo>()
        .Property(v => v.Id)
        .IsRequired()
        .ValueGeneratedOnAdd();
    builder.Entity<Vehiculo>()
        .Property(v => v.Marca);
    builder.Entity<Vehiculo>()
        .Property(v => v.Modelo);
    builder.Entity<Vehiculo>()
        .Property(v => v.VelocidadMax);
    builder.Entity<Vehiculo>()
        .Property(v => v.Consumo);
    builder.Entity<Vehiculo>()
        .Property(v => v.Dimensiones);
    builder.Entity<Vehiculo>()
        .Property(v => v.Peso);
    builder.Entity<Vehiculo>()
        .Property(v => v.Clase);
    builder.Entity<Vehiculo>()
        .Property(v => v.Transmision);
    builder.Entity<Vehiculo>()
        .Property(v => v.Tiempo);
    builder.Entity<Vehiculo>()
        .Property(v => v.TipoTiempo);
    builder.Entity<Vehiculo>()
        .Property(v => v.CostoAlquiler);
    builder.Entity<Vehiculo>()
        .Property(v => v.LugarRecojo);
    builder.Entity<Vehiculo>()
        .Property(v => v.UrlImagen);
    builder.Entity<Vehiculo>()
        .Property(v => v.ContratoAlquilerPdf);
    
    //Relaciones de Vehiculo
    builder.Entity<Vehiculo>()
        .HasOne(v => v.Propietario)
        .WithMany()
        .HasForeignKey(v => v.PropietarioId);
    builder.Entity<Vehiculo>()
        .HasOne(v => v.Arrendatario)
        .WithMany()
        .HasForeignKey(v => v.ArrendatarioId);
    builder.Entity<Vehiculo>()
        .HasOne(v => v.Alquiler)
        .WithMany()
        .HasForeignKey(v => v.AlquilerId);
    }
}