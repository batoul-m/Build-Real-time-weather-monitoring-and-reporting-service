using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherMonotring;

namespace WeatherMonitoring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Set up dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IWeatherMonitoringService>(sp => new WeatherMonitoringService("path/to/your/configuration.json"))
                .AddTransient<IReadingData>(sp =>
                {
                    Console.WriteLine("Enter your choice (Json or Xml): ");
                    var choice = Console.ReadLine();
                    if (choice is null) throw new ArgumentException("Choice cannot be null");
                    
                    if (choice.Equals("Json", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Enter JSON string: ");
                        var jsonString = Console.ReadLine();
                        if (string.IsNullOrEmpty(jsonString)) throw new ArgumentException("Enter a valid JSON string");
                        if (jsonString.StartsWith("{") && jsonString.EndsWith("}"))
                        {
                            return new ReadingJsonData(jsonString);
                        }
                        throw new ArgumentException("Not a valid JSON string");
                    }
                    else if (choice.Equals("Xml", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Enter XML string: ");
                        var xmlString = Console.ReadLine();
                        if (string.IsNullOrEmpty(xmlString)) throw new ArgumentException("Enter a valid XML string");
                        if (xmlString.StartsWith("<") && xmlString.EndsWith(">"))
                        {
                            return new ReadingXmlData(xmlString);
                        }
                        throw new ArgumentException("Not a valid XML string");
                    }
                    throw new ArgumentException("Not a valid choice");
                })
                .BuildServiceProvider();

            // Resolve the services
            var readingData = serviceProvider.GetRequiredService<IReadingData>();
            readingData.ReadingData();

            var configurationFilePath = "";
            var weatherMonitoringService = serviceProvider.GetRequiredService<IWeatherMonitoringService>();
            weatherMonitoringService.LoadBotConfiguration(configurationFilePath);
        }
    }
}
