using Microsoft.EntityFrameworkCore;
using PortalGalaxy.Entities;

namespace PortalGalaxy.DataAccess
{
    public class PortalGalaxyDbContext : DbContext
    {
        public PortalGalaxyDbContext(DbContextOptions<PortalGalaxyDbContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocaldb;Integrated Security=true;Database=PortalTestDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>().HasKey(o => o.Id);
            modelBuilder.Entity<Alumno>().HasData(new List<Alumno>()
            {
                new() { Id = 1, NombreCompleto = "Erick Velasco", Correo = "erick@gmail.com" },
                new() { Id = 2, NombreCompleto = "Juan Carlos", Correo = "juanca@gmail.com" },
                new() { Id = 3, NombreCompleto = "Pepe Lucho", Correo = "pepe@gmail.com" },
                new() { Id = 4, NombreCompleto = "Coco Perez", Correo = "coco@gmail.com" },
            });
        }
    }
}
