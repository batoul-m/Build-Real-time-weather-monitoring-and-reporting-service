namespace WeatherMonotring{
  public class ReadingJsonData : IReadingData{
    public string JsonString { get; set; }
    public ReadingJsonData(string jsonString){
      JsonString = jsonString;
    }

    void IReadingData.ReadingData(){
      throw new NotImplementedException();
    }
  }  
}