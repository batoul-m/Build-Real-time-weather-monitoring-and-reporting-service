using System;

namespace WeatherMonotring{
    public class BotConfiguration{
        public bool Enabled { get; set; }
        public double Threshold { get; set; }
        public string Message { get; set; } = "";
        public BotConfiguration? SnowBot { get; internal set; }
        public BotConfiguration? SunBot { get; internal set; }
        public BotConfiguration? RainBot { get; internal set; }
    } 
}