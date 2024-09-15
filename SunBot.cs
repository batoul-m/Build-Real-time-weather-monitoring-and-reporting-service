using System;

namespace WeatherMonotring{        
    public class SunBot : WeatherBot
    {
        public SunBot(WeatherData weatherData, BotConfiguration configuration) : base(weatherData, configuration){}
        public override void ProcessWeatherData()
        {
            if (WeatherData.Temperature > Configuration.Threshold && Configuration.Enabled)
            {
                Console.WriteLine($"{Configuration.Message}");
            }
        }
    }
}