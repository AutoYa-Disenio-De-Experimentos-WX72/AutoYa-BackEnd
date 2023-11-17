using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Shared.Extensions;
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
    
    public DbSet<User> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Configuración de la entidad Alquiler
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

        // Configuración de la entidad Arrendatario
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
            .HasOne(m => m.Arrendatario)
            .WithMany(a => a.Mantenimientos)
            .HasForeignKey(m => m.ArrendatarioId);

        builder.Entity<Mantenimiento>()
            .HasOne(m => m.Propietario)
            .WithMany(p => p.Mantenimientos)
            .HasForeignKey(m => m.PropietarioId);

        // Configuración de la entidad Notificacion
        builder.Entity<Notificacion>()
            .HasOne(n => n.Propietario)
            .WithMany(p => p.Notificaciones)
            .HasForeignKey(n => n.PropietarioId);

        builder.Entity<Notificacion>()
            .HasOne(n => n.Arrendatario)
            .WithMany(a => a.Notificaciones)
            .HasForeignKey(n => n.ArrendatarioId);

        // Configuración de la entidad Propietario
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
            .HasOne(s => s.Alquiler)
            .WithMany(a => a.Solicitudes)
            .HasForeignKey(s => s.AlquilerId);

        // Configuración de la entidad Vehiculo
        builder.Entity<Vehiculo>()
            .HasOne(v => v.Propietario)
            .WithMany(p => p.Vehiculos)
            .HasForeignKey(v => v.PropietarioId);

        builder.Entity<Vehiculo>()
            .HasOne(v => v.Arrendatario)
            .WithMany(a => a.VehiculosAlquilados)
            .HasForeignKey(v => v.ArrendatarioId)
            .IsRequired(false); // Hacerlo opcional si no todos los vehículos están alquilados;

        builder.Entity<Vehiculo>()
            .HasOne(v => v.Alquiler)
            .WithOne(a => a.Vehiculo)
            .HasForeignKey<Vehiculo>(v => v.AlquilerId)
            .IsRequired(false); // Hacerlo opcional si no todos los vehículos están alquilados
    
        /*
         * --------------------------------------------
         * Configuración para los usuarios
         */
        
        builder.Entity<User>().ToTable("Usuarios");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => 
            p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => 
            p.Email).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        
    builder.UseSnakeCaseNamingConvention();
    }
}