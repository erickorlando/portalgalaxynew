namespace PortalGalaxy.UnitTests;

public class PortalGalaxyTests
{
    [Fact]
    public void SumaTest()
    {
        // Arrange

        var a = 5;
        var b = 6;

        var expected = 11;

        // Act

        var result = a + b;

        // Assert

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void SumaIncorrectaTest()
    {
        // Arrange

        var a = 5;
        var b = 6;

        var expected = 12;

        // Act

        var result = a + b;

        // Assert

        Assert.NotEqual(expected, result);
    }
    
    [Fact]
    public void SumaDebeFallarTest()
    {
        // Arrange

        var a = 5;
        var b = 6;

        var expected = 15;

        // Act

        var result = a + b;

        // Assert

        Assert.NotEqual(expected, result);
    }
    
    [Theory]
    [InlineData(5, 11)]
    [InlineData(6, 12)]
    [InlineData(7, 13)]
    public void SumaMultipleTest(int sumando, int expected)
    {
        // Arrange

        var b = 6;

        // Act

        var result = sumando + b;

        // Assert

        Assert.Equal(expected, result);
    }
}