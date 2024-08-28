using System;

namespace WeatherMonotring{        
    public class SnowBot : WeatherBot
    {
        public SnowBot(WeatherData weatherData, BotConfiguration configuration) : base(weatherData, configuration){}
        public override void ProcessWeatherData()
        {
            if (WeatherData.Temperature < Configuration.Threshold && Configuration.Enabled)
            {
                Console.WriteLine($"{Configuration.Message}");
            }
        }
    }
}