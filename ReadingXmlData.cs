using System;
using System.IO;
using System.Xml.Serialization;

namespace WeatherMonotring
{
  public class ReadingXmlData : ReadingData{
    public required string XmlString { get; set; }
    public ReadingXmlData(string xmlString){
      XmlString = xmlString;
    }
    void ReadingData.ReadingData(){
        var serializer = new XmlSerializer(typeof(WeatherData));
        using (var stringReader = new StringReader(XmlString))
        {
            WeatherData weatherData = (WeatherData)serializer.Deserialize(stringReader);
        }

    }
    }  
}