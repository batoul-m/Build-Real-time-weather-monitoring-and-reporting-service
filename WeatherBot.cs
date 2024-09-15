using System;

namespace WeatherMonotring{
    public abstract class WeatherBot{
        public WeatherData WeatherData;
        protected readonly BotConfiguration Configuration;

        public WeatherBot(WeatherData weatherData, BotConfiguration configuration)
        {
            WeatherData = weatherData;
            Configuration = configuration;
        }

        public abstract void ProcessWeatherData();
    } 
}