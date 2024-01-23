using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Application
{
    // The WeatherInfo class contains the definition of data structures that will be used to store weather information.
    class WeatherInfo
    {
        // The coord class represents geographical coordinates (longitude and latitude).
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        // The weather class represents information about weather conditions, such as the main category, description, and icon.
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        // The main class contains main weather information such as temperature, pressure, and humidity.
        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; } 
        }
        // The wind class represents wind information, such as speed.
        public class wind
        {
            public double speed { get; set; }
        }
        // The sys class contains information about sunrise and sunset times.
        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }
        // The root class is the main class that aggregates all weather information.
        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys { get; set; }
        }
    }
}
