using WeatherMonotring;
namespace WeatherMonitoring{
    public interface IWeatherMonitoringService{
        List<WeatherBot> InitializeBots(BotConfiguration config);
        BotConfiguration LoadBotConfiguration(string filePath);
        void ProcessWeatherData(WeatherData weatherData);
    }
}
