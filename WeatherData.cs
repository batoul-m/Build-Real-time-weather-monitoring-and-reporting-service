using System;

namespace WeatherMonotring{
    public class WeatherData{
        public string CityName { get; set; }
        public  double Temperature{ get; set; }
        public double Humidity { get; set; } 
        public WeatherData(){}
        public WeatherData(string cityName,double temperature,double humidity){
            CityName = cityName.Length != 0 ? cityName : throw new ArgumentException("city name can't be empty") ;
            Temperature = temperature;
            Humidity = humidity;

        }
    } 
}