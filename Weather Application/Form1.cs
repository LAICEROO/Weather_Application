using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using static Weather_Application.WeatherInfo;

namespace Weather_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        // Klucz API do OpenWeatherMap
        string APIKey = "2405d01daceb793f6062146c0b83f91d";

        // Obsługa zdarzenia ładowania formularza
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Obsługa zdarzenia, gdy przycisk wyszukiwania jest kliknięty
            getWeather();
        }
        //Metoda do pobierania informacji pogodowych z API OpenWeatherMap
        void getWeather()
        {
            // Użycie instrukcji using zapewnia właściwe zwolnienie zasobów WebClient
            using (WebClient web = new WebClient())
            {
                try
                {
                    // Budowanie adresu URL żądania API
                  0  string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, APIKey);

                    // Pobieranie JSON z odpowiedzi API
                    var json = web.DownloadString(url);

                    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                    // Aktualizacja interfejsu użytkownika danymi pogodowymi
                    labTemp.Text = Math.Round(((float)Info.main.temp - 273.15), 2).ToString("0");//Temperatura domyślnie podawana jest w kelwinach dlatego odejmujemy -273.15
                    labHum.Text = Info.main.humidity.ToString(); //Konwertuje wartość wilgotności na ciąg znaków 
                    labDetails.Text = Info.weather[0].description; //Odnosimy się do pierwszego elementu w kolekcji
                    labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString(); //Konwertuje czas zachodu słońca na krótki ciąg znaków reprezentujący tylko godzinę i minutę
                    labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString(); //Konwertuje czas wschodu słońca na krótki ciąg znaków reprezentujący tylko godzinę i minutę
                    labWindSpeed.Text = (Info.wind.speed * 3.6).ToString(); //Możymy razy 3.6, ponieważ domyślna prędkość podowana jest w m/s
                    labPressure.Text = Info.main.pressure.ToString(); //Konwertuje wartość ciśnienie na ciąg znaków 
                }
                catch (WebException ex)
                {
                    // Obsługa błędów sieciowych
                    MessageBox.Show("Błąd sieciowy podczas pobierania danych pogodowych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (JsonException ex)
                {
                    // Obsługa błędów deserializacji JSON
                    MessageBox.Show("Błąd deserializacji danych JSON: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Obsługa innych błędów
                    MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Metoda do konwersji znacznika czasu Unix na DateTime
        DateTime convertDateTime(long sec)
        {
                                        //rok, miesiac, dzien, godzina, minuta, sekunda, milisekunda
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day; 
        }
    }
}
