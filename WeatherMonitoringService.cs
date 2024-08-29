using System;
using System.Text.Json;

namespace WeatherMonotring{
    public class WeatherMonitoringService{
            private readonly List<WeatherBot> _bots;
            public WeatherMonitoringService(string configurationFilePath)
            {
                BotConfiguration botConfig = LoadBotConfiguration(configurationFilePath);
                if (botConfig is null){
                    throw new ArgumentException("Bot configuration could not be loaded.");
                }

                _bots = InitializeBots(botConfig);
            }
            private List<WeatherBot> InitializeBots(BotConfiguration config)
            {
                var bots = new List<WeatherBot>();
                if (config.RainBot != null){
                    bots.Add(new RainBot(null, config.RainBot));
                }
                else{
                    Console.WriteLine("RainBot configuration is missing.");
                }
                if (config.SunBot != null){
                    bots.Add(new SunBot(null, config.SunBot));
                }else{
                    Console.WriteLine("SunBot configuration is missing.");
                }
                if (config.SnowBot != null){
                    bots.Add(new SnowBot(null, config.SnowBot));
                }else{
                    Console.WriteLine("SnowBot configuration is missing.");
                }
                return bots;
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