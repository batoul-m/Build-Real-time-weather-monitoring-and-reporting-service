using Xunit;
using Moq;
using FluentAssertions;
using AutoFixture;
using System.Text.Json;
using WeatherMonitoring;
using WeatherMonotring;

public class WeatherMonitoringServiceTests
{
    private readonly Fixture _fixture;
    private readonly Mock<BotConfiguration> _mockBotConfig;
    private readonly string _validJsonFilePath = "testConfiguration.json";

    public WeatherMonitoringServiceTests()
    {
        _fixture = new Fixture();
        _mockBotConfig = new Mock<BotConfiguration>();

        // Setup a valid configuration
        var validConfig = new BotConfiguration
        {
            RainBot = new BotConfiguration { Threshold = 70, Enabled = true, Message = "It's raining!" },
            SunBot = new BotConfiguration { Threshold = 30, Enabled = true, Message = "It's sunny!" },
            SnowBot = new BotConfiguration { Threshold = 0, Enabled = true, Message = "It's snowing!" }
        };

        // Write config to file (simulating reading from a file)
        File.WriteAllText(_validJsonFilePath, JsonSerializer.Serialize(validConfig));
    }

    [Fact]
    public void ShouldThrowArgumentException_WhenConfigurationFileIsNullOrEmpty()
    {
        // Act
        Action act = () => new WeatherMonitoringService("");
        // Assert
        act.Should().Throw<ArgumentException>()
           .WithMessage("Configuration file path cannot be null or empty.");
    }

    [Fact]
    public void ShouldInitializeBots_WhenValidConfigFileIsProvided()
    {
        // Act
        var weatherService = new WeatherMonitoringService(_validJsonFilePath);
        // Assert
        weatherService.Should().NotBeNull();
        weatherService.InitializeBots(_mockBotConfig.Object).Should().HaveCount(3);
    }

    [Fact]
    public void ShouldProcessWeatherData_ForAllBots()
    {
        // Arrange
        var weatherData = _fixture.Create<WeatherData>();
        var weatherService = new WeatherMonitoringService(_validJsonFilePath);
        // Act
        Action act = () => weatherService.ProcessWeatherData(weatherData);
        // Assert
        act.Should().NotThrow<Exception>();
    }
}
