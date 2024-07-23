using Microsoft.EntityFrameworkCore;
using Moq;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Negocio.Implementaciones;
using PortalGalaxy.Negocio.Interfaces;

namespace PortalGalaxy.UnitTests;

public class RepositoryTests
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
    public void ProbarListarConRepository()
    {
        // Arrange
        var alumnoRepository = new AlumnoRepository(ArrangeDataBase());

        // Act

        var lista = alumnoRepository.List();

        // Assert

        Assert.NotEmpty(lista);

    }
    
    
    [Fact]
    public void ProbarListarConRepositoryPeroSinArrange()
    {
        // Arrange
        var alumnoRepository = new Mock<IAlumnoRepository>();
        alumnoRepository.Setup(s => s.List()).Returns(new List<Alumno>()
        {
            new Alumno() { NombreCompleto = It.IsAny<string>(), Correo = It.IsAny<string>() }
        });

        // Act

        var lista = alumnoRepository.Object.List();

        // Assert

        Assert.NotEmpty(lista);

    }

    [Fact]
    public void ProbarMetodoAddDelRepository()
    {
        // Arrange
        var alumnoRepository = new AlumnoRepository(ArrangeDataBase());
        var expected = 5;

        // Act
        alumnoRepository.Add(new Alumno()
        {
            NombreCompleto = "Juanito Martinez",
            Correo = "juanito@microsoft.com"
        });

        var actual = alumnoRepository.List().Count;

        // Assert
        Assert.Equal(expected, actual);
    }
}