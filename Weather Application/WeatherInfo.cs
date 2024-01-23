using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Application
{
    // Klasa WeatherInfo zawiera definicję struktur danych, które będą używane do przechowywania informacji pogodowych.
    class WeatherInfo
    {
        // Klasa coord reprezentuje współrzędne geograficzne (długość i szerokość geograficzną)
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        // Klasa weather reprezentuje informacje dotyczące warunków pogodowych, takie jak główna kategoria, opis i ikona
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        // Klasa main zawiera główne informacje pogodowe, takie jak temperatura, ciśnienie i wilgotność
        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; } 
        }
        // Klasa wind reprezentuje informacje dotyczące wiatru, takie jak prędkość
        public class wind
        {
            public double speed { get; set; }
        }
        // Klasa sys zawiera informacje o wschodzie i zachodzie słońca
        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }
        // Klasa root jest główną klasą, która agreguje wszystkie informacje pogodowe
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
