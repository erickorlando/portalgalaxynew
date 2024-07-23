using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;

namespace PortalGalaxy.UnitTests
{
    public class DbContextTests
    {
        private static PortalGalaxyDbContext ArrangeDataBase()
        {
            var options = new DbContextOptionsBuilder<PortalGalaxyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PortalGalaxyDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public void ProbarQueHayDatosEnBaseDatosEnMemoria()
        {
            // Arrange
            var dbContext = ArrangeDataBase();

            // Act
            var actual = dbContext.Set<Alumno>().Count();

            // Assert
            Assert.NotEqual(0, actual);

        }
        
        [Fact]
        public void ProbarQueSePuedeAgregarMasRegistros()
        {
            // Arrange
            var dbContext = ArrangeDataBase();
            var alumnoNuevo = new Alumno
            {
                NombreCompleto = "Pepito Martinez",
                Correo = "pepito@hotmail.com"
            };

            // Act
            dbContext.Set<Alumno>().Add(alumnoNuevo);
            dbContext.SaveChanges();

            var actual = dbContext.Set<Alumno>().Count();

            // Assert
            Assert.Equal(5, actual);

        }
        
        [Fact]
        public void ProbarQueSePuedeAgregarMuchosRegistrosConBucle()
        {
            // Arrange
            var dbContext = ArrangeDataBase();
            var alumnoNuevo = new Alumno
            {
                NombreCompleto = "Pepito Martinez",
                Correo = "pepito@hotmail.com"
            };

            // Act
            for (int i = 0; i < 10; i++)
            {
                alumnoNuevo.Id = i + 5;
                dbContext.Set<Alumno>().Add(alumnoNuevo);
                dbContext.SaveChanges(); 
            }

            var actual = dbContext.Set<Alumno>().Count();

            // Assert
            Assert.Equal(14, actual);

        }
    }
}
