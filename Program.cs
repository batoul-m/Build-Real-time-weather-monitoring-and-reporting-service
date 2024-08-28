using Microsoft.VisualBasic;
namespace WeatherMonotring;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("enter your choice do you want to read from Json or Xml");
        var Choice = Console.ReadLine();
        if(Choice is null) throw new ArgumentException("Choice can not be null");
        else if(Choice.Equals("Json", StringComparison.OrdinalIgnoreCase)){
            var JsonString = Console.ReadLine();
            if (string.IsNullOrEmpty(JsonString))throw new ArgumentException("enter a valid Json String");
            else if(JsonString.StartsWith("<") && JsonString.EndsWith(">")){
                ReadingJsonData readingJsonData = new ReadingJsonData(JsonString);
            }else throw new ArgumentException("not valid Json string");

        } 
        else if(Choice.Equals("Xml", StringComparison.OrdinalIgnoreCase)){
            var XmlString = Console.ReadLine();
            if (string.IsNullOrEmpty(XmlString))throw new ArgumentException("enter a valid Json String");
            else if(XmlString.StartsWith("<") && XmlString.EndsWith(">")){
                ReadingXmlData readingXmlData = new ReadingXmlData(XmlString);
            }else throw new ArgumentException("non valid Xml string"); 
        }
        else throw new ArgumentException("not valid choice");

        // 
        
    }
}