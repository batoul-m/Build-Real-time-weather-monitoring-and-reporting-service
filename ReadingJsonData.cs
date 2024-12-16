using System;
using System.Text.Json;

namespace WeatherMonotring
{
  public class ReadingJsonData : ReadingData{
    public required string JsonString { get; set; }
    public ReadingJsonData(string jsonString){
      JsonString = jsonString;
    }
    void ReadingData.ReadingData(){
        WeatherData? weatherData = JsonSerializer.Deserialize<WeatherData>(JsonString);      
      }
    }  
}