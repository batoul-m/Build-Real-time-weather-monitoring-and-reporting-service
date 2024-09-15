using Microsoft.VisualBasic;
namespace WeatherMonotring;
internal class Program
{
    private static void Main(string[] args)
    {
        //Rrading data acorrding to user choice
        Console.WriteLine("enter your choice do you want to read from Json or Xml");
        var Choice = Console.ReadLine();
        if(Choice is null) throw new ArgumentException("Choice can not be null");
        else if(Choice.Equals("Json", StringComparison.OrdinalIgnoreCase)){
            var JsonString = Console.ReadLine();
            if (string.IsNullOrEmpty(JsonString))throw new ArgumentException("enter a valid Json String");
            else if(JsonString.StartsWith("<") && JsonString.EndsWith(">")){
                ReadingData readingJsonData = new ReadingJsonData(JsonString);
            }else throw new ArgumentException("not valid Json string");

        } 
        else if(Choice.Equals("Xml", StringComparison.OrdinalIgnoreCase)){
            var XmlString = Console.ReadLine();
            if (string.IsNullOrEmpty(XmlString))throw new ArgumentException("enter a valid Json String");
            else if(XmlString.StartsWith("<") && XmlString.EndsWith(">")){
                ReadingData readingXmlData = new ReadingXmlData(XmlString){XmlString = XmlString};
            }else throw new ArgumentException("non valid Xml string"); 
        }
        else throw new ArgumentException("not valid choice");

        // Load the bot configuration
        var configFilePath = "path/to/your/configuration.json";
        var weatherMonitoringService = new WeatherMonitoringService(configFilePath);
        
    }
}