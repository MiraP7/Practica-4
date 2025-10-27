using Microsoft.EntityFrameworkCore;
using ProductosApi.Models;

namespace ProductosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Productos
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000);

                entity.Property(e => e.Precio)
                    .HasPrecision(18, 2);

                entity.Property(e => e.Stock)
                    .IsRequired();

                entity.Property(e => e.FechaCreacion)
                    .IsRequired();

                entity.Property(e => e.FechaActualizacion)
                    .IsRequired();

                // Índices
                entity.HasIndex(e => e.Nombre)
                    .IsUnique();
            });

            // Datos iniciales de ejemplo
            modelBuilder.Entity<Producto>().HasData(
                new Producto 
                { 
                    Id = 1, 
                    Nombre = "Laptop Dell XPS 15", 
                    Descripcion = "Laptop de alta performance para desarrollo", 
                    Precio = 1299.99m, 
                    Stock = 5,
                    FechaCreacion = DateTime.UtcNow,
                    FechaActualizacion = DateTime.UtcNow
                },
                new Producto 
                { 
                    Id = 2, 
                    Nombre = "Monitor LG 4K", 
                    Descripcion = "Monitor Ultra HD 27 pulgadas", 
                    Precio = 449.99m, 
                    Stock = 10,
                    FechaCreacion = DateTime.UtcNow,
                    FechaActualizacion = DateTime.UtcNow
                },
                new Producto 
                { 
                    Id = 3, 
                    Nombre = "Teclado Mecánico RGB", 
                    Descripcion = "Teclado gaming con switches mecánicos", 
                    Precio = 159.99m, 
                    Stock = 15,
                    FechaCreacion = DateTime.UtcNow,
                    FechaActualizacion = DateTime.UtcNow
                }
            );
        }
    }
}
