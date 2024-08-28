using System;
using System.Text.Json;

namespace WeatherMonotring{
    public class WeatherMonitoringService{
            private readonly List<WeatherBot> _bots;
            private readonly BotConfiguration _botConfiguration;

            public WeatherMonitoringService(string configurationFilePath)
            {
                _bots = new List<WeatherBot>();
                _botConfiguration = LoadBotConfiguration(configurationFilePath);

                // Create bots based on configuration
                _bots.Add(new RainBot(null, _botConfiguration.RainBot is not null ? _botConfiguration.RainBot : throw new ArgumentException("null")));
                _bots.Add(new SunBot(null, _botConfiguration.SunBot is not null ? _botConfiguration.SunBot : throw new ArgumentException("null")));
                _bots.Add(new SnowBot(null, _botConfiguration.SnowBot is not null ? _botConfiguration.SnowBot : throw new ArgumentException("null")));
            }

            private BotConfiguration LoadBotConfiguration(string filePath)
            {
                try
                {
                    using (var reader = new StreamReader(filePath)){
                        return JsonSerializer.Deserialize<BotConfiguration>(reader.ReadToEnd());
                    }
                }catch (Exception ex){
                    Console.WriteLine($"Error loading configuration: {ex.Message}");
                    return null;
                }
            }

            public void ProcessWeatherData(WeatherData weatherData)
            {
                foreach (var bot in _bots){
                    bot.WeatherData = weatherData;
                    bot.ProcessWeatherData();
                }
            }

        }
}