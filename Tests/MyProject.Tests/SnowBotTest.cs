using Xunit;
using Moq;
using FluentAssertions;
using AutoFixture;
using System;
using System.IO;
using System.Collections.Generic;
using WeatherMonotring;

public class SnowBotTestShould{
    private readonly Fixture _fixture;
    private readonly Mock<WeatherData> _mockWeatherData;
    private readonly Mock<BotConfiguration> _mockConfiguration;
    private readonly SnowBot _snowBot;
    public SnowBotTestShould(){
        _fixture = new Fixture();
        _mockWeatherData = new Mock<WeatherData>();
        _mockConfiguration = new Mock<BotConfiguration>();

        // Set up mock configuration 
        _mockConfiguration.Setup(x => x.Enabled).Returns(true);
        _mockConfiguration.Setup(x => x.Message).Returns("It's snowing!");
        _mockConfiguration.Setup(x => x.Threshold).Returns(0);

        //Set up mock Data
        _mockWeatherData.Setup(w => w.Temperature).Returns(0);
        _snowBot = new SnowBot(_mockWeatherData.Object,_mockConfiguration.Object);
    }
    [Fact]
    public void OutputMessage_WhenTemperatureIsUnderThreshold(){
        //Act
        using(var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            _snowBot.ProcessWeatherData();

            //Assert
            consoleOutput.ToString().Should().Contain("it's getting chilly!");
        }

    }
    [Fact]
    public void NotOutputMessage_WhenTemperatureIsUnderThreshold(){
        //Arrange
        _mockWeatherData.Setup(x => x.Temperature).Returns(20);

        //Act
        using (var consoleOutput = new StringWriter()){
            Console.SetOut(consoleOutput);
            _snowBot.ProcessWeatherData();

            //Assert
            consoleOutput.ToString().Should().BeEmpty();
        }

    }
    
}