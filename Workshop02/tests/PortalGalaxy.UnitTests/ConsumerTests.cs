using Moq;
using PortalGalaxy.Negocio.Interfaces;
using PortalGalaxy.Negocio.Services;

namespace PortalGalaxy.UnitTests
{
    public class ConsumerTests
    {
        [Fact]
        public void Consumer_DebeRetornarUnValor()
        {
            // Arrange
            var mockService = new Mock<IService>();
            mockService.Setup(service => service.GetValue()).Returns(42);

            var consumer = new Consumer(mockService.Object);

            // Act
            var result = consumer.Consume();

            // Assert
            Assert.Equal(42, result);
        }

        [Fact]
        public void Consumer_DebeVerificarQueLaListaHasidoInvocada()
        {
            // Arrange
            var mockService = new Mock<IService>();
            mockService.Setup(service => service.GetData()).Returns(new List<string>
            {
                "Capitan America",
                "Hulk",
                "Iron Man",
                "Hawkeye"
            });

            var consumer = new Consumer(mockService.Object);

            // Act
            consumer.TrabajarConDatos();

            // Assert
            mockService.Verify(s => s.GetData(), Times.Once); // Verificar que al menos se invoco 1 vez.
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(10)]
        public void Consumer_DebeProbarLaLlamadaAlMetodoGetData(short valor)
        {
            // Arrange
            var mockService = new Mock<IService>();
            mockService.Setup(service => service.GetData()).Returns(new List<string>
            {
                "Capitan America",
                "Hulk",
                "Iron Man",
                "Hawkeye"
            });

            var consumer = new Consumer(mockService.Object);

            // Act
            consumer.TrabajarConDatos(valor);

            // Assert
            mockService.Verify(s => s.GetData(), Times.Once); // Verificar que al menos se invoco 1 vez.
        }

        [Fact]
        public void Consumer_MetodoGetDataNoSeEjecuta()
        {
            // Arrange
            var mockService = new Mock<IService>();
            mockService.Setup(service => service.GetData()).Returns(new List<string>
            {
                "Capitan America",
                "Hulk",
                "Iron Man",
                "Hawkeye"
            });

            var consumer = new Consumer(mockService.Object);

            // Act
            consumer.TrabajarConDatos(1);

            // Assert
            mockService.Verify(s => s.GetData(), Times.Never); // Verificar que al menos se invoco 1 vez.
        }
        
        [Fact]
        public void Consumer_MetodoArrojaExcepcion()
        {
            // Arrange
            var mockService = new Mock<IService>();
            mockService.Setup(service => service.GetData()).Returns(new List<string>
            {
                "Capitan America",
                "Hulk",
                "Iron Man",
                "Hawkeye"
            });

            var consumer = new Consumer(mockService.Object);

            // Act
            Action metodo = () => consumer.TrabajarConDatos(100);

            // Assert
            Assert.Throws<ApplicationException>(metodo);
        }
    }
}
