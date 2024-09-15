using Xunit;
using Moq;
using FluentAssertions;
using AutoFixture;
using WeatherMonotring;
public class RainBotTestShould{
    private readonly Fixture _fixture;
    private readonly Mock<WeatherData> _mockWeatherData;
    private readonly Mock<BotConfiguration> _mockConfiguration;
    private readonly RainBot _rainBot;

    public RainBotTestShould()
    {
        _fixture = new Fixture();
        _mockWeatherData = new Mock<WeatherData>();
        _mockConfiguration = new Mock<BotConfiguration>();

        // Setup mock configuration
        _mockConfiguration.Setup(c => c.Threshold).Returns(70);
        _mockConfiguration.Setup(c => c.Enabled).Returns(true);
        _mockConfiguration.Setup(c => c.Message).Returns("It's raining!");

        // Setup mock weather data
        _mockWeatherData.Setup(w => w.Humidity).Returns(80);

        // Create instance of RainBot
        _rainBot = new RainBot(_mockWeatherData.Object, _mockConfiguration.Object);
    }

    [Fact]
    public void OutputMessage_WhenHumidityIsAboveThreshold()
    {
        // Act
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            _rainBot.ProcessWeatherData();
            
            // Assert
            consoleOutput.ToString().Should().Contain("It's raining!");
        }
    }

    [Fact]
    public void NotOutputMessage_WhenHumidityIsBelowThreshold()
    {
        // Arrange
        _mockWeatherData.Setup(w => w.Humidity).Returns(50); 

        // Act
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            _rainBot.ProcessWeatherData();

            // Assert
            consoleOutput.ToString().Should().BeEmpty();
        }
    }
}
