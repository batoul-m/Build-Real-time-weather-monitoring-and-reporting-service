using System.Text.Json;
using WeatherMonotring;
namespace WeatherMonitoring{
    public class WeatherMonitoringService : IWeatherMonitoringService{
        private readonly List<WeatherBot> _bots;
        public WeatherMonitoringService(string configurationFilePath)
        {
            if (string.IsNullOrEmpty(configurationFilePath))
                throw new ArgumentException("Configuration file path cannot be null or empty.", nameof(configurationFilePath));
            var botConfig = LoadBotConfiguration(configurationFilePath);
            if (botConfig is null)
                throw new ArgumentException("Bot configuration could not be loaded.");
            _bots = InitializeBots(botConfig);
        }
        public List<WeatherBot> InitializeBots(BotConfiguration config)
        {
            var bots = new List<WeatherBot>();
            WeatherData defaultWeatherData = new WeatherData();

            if (config.RainBot is not null)
                bots.Add(new RainBot(defaultWeatherData, config.RainBot));
            else
                Console.WriteLine("RainBot configuration is missing.");

            if (config.SunBot is not null)            
                bots.Add(new SunBot(defaultWeatherData, config.RainBot));
            else
                Console.WriteLine("SunBot configuration is missing.");

            if (config.SnowBot is not null)            
                bots.Add(new SnowBot(defaultWeatherData, config.SnowBot));            
            else            
                Console.WriteLine("SnowBot configuration is missing.");
            return bots;
        }

        public BotConfiguration LoadBotConfiguration(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<BotConfiguration>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                return null;
            }
        }
        public void ProcessWeatherData(WeatherData weatherData)
        {
            if (weatherData == null)
                throw new ArgumentNullException(nameof(weatherData));
            foreach (var bot in _bots)
            {
                bot.WeatherData = weatherData;
                bot.ProcessWeatherData();
            }
        }
    }
}
