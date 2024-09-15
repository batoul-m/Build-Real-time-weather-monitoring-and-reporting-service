using System.Xml.Serialization;
namespace WeatherMonotring
{
  public class ReadingXmlData : IReadingData{
    public string XmlString { get; set; }
    public ReadingXmlData(string xmlString){
      XmlString = xmlString;
    }
    void IReadingData.ReadingData(){
        var serializer = new XmlSerializer(typeof(WeatherData));
        using (var stringReader = new StringReader(XmlString))
        {
            WeatherData weatherData = (WeatherData)serializer.Deserialize(stringReader);
        }

    }
    }  
}