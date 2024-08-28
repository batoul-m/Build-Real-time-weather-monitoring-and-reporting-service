using System;

namespace WeatherMonotring{        
    public class RainBot : WeatherBot{
        public RainBot(WeatherData weatherData, BotConfiguration configuration) : base(weatherData, configuration){}
        public override void ProcessWeatherData()
        {
            if (WeatherData.Humidity > Configuration.Threshold && Configuration.Enabled)
            {
                Console.WriteLine($"{Configuration.Message}");
            }
        }
    }
}