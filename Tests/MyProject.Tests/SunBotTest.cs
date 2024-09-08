using Xunit;
using Moq;
using FluentAssertions;
using AutoFixture;
using System;
using System.IO;
using System.Collections.Generic;
using WeatherMonotring;

public class SunBotTestShould{
    private readonly Fixture _fixture;
    private readonly Mock<WeatherData> _mockWeatherData;
    private readonly Mock<BotConfiguration> _mockConfiguration;
    private readonly SunBot _sunBot;
    public SunBotTestShould(){
        _fixture = new Fixture();
        _mockWeatherData = new Mock<WeatherData>();
        _mockConfiguration = new Mock<BotConfiguration>();

        // Setup mock configuration
        _mockConfiguration.Setup(c => c.Threshold).Returns(30);
        _mockConfiguration.Setup(c => c.Enabled).Returns(true);
        _mockConfiguration.Setup(c => c.Message).Returns("It's sunny!");

        // Setup mock weather data
        _mockWeatherData.Setup(x => x.Temperature).Returns(40);

        _sunBot = new SunBot(_mockWeatherData.Object,_mockConfiguration.Object);
    }
    [Fact]
    public void OutputMessage_WhenTemperatureIsAboveThreshold()
    {
        // Act
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            _sunBot.ProcessWeatherData();
            
            // Assert
            consoleOutput.ToString().Should().Contain("it's a scorcher");
        }
    }
    [Fact]
    public void NotOutputMessage_WhenTemperatureIsBelowThreshold()
    {
        // Arrange
        _mockWeatherData.Setup(w => w.Temperature).Returns(10); 

        // Act
        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            _sunBot.ProcessWeatherData();

            // Assert
            consoleOutput.ToString().Should().BeEmpty();
        }
    } 
}