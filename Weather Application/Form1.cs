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
using static System.Windows.Forms.LinkLabel;

namespace Weather_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        // API Key for OpenWeatherMap 
        string APIKey = "2405d01daceb793f6062146c0b83f91d";

        // Event handler for form loading
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Event handler for the search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Event handler when the search button is clicked
           getWeather();
        }
        // Method to retrieve weather information from the OpenWeatherMap API
        void getWeather()
        {
            // Using statement ensures proper disposal of WebClient resources
            using (WebClient web = new WebClient())
            {
                try
                {
                    // Building the API request URL
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, APIKey);

                    // Downloading JSON from the API response
                    var json = web.DownloadString(url);

                    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                    // Updating the user interface with weather data
                    labTemp.Text = Math.Round(((float)Info.main.temp - 273.15), 2).ToString();// The temperature is initially provided in Kelvin. This line converts it to Celsius by subtracting 273.15 
                    labTempF.Text = Math.Round(((float)Info.main.temp * 9 / 5 - 459.67), 2).ToString(); //The temperature is initially provided in Kelvin, so this line converts it to Fahrenheit by using the formula: Fahrenheit = (Kelvin * 9 / 5) - 459.67.
                    labHum.Text = Info.main.humidity.ToString();  
                    labDetails.Text = Info.weather[0].description; 
                    labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString(); // Converts the sunset time to a short string representing only the hour and minute.
                    labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();// Converts the sunrise time to a short string representing only the hour and minute.
                    labWindSpeed.Text = Math.Round(Info.wind.speed * 3.6, 2).ToString();  //Multiply by 3.6 because the default speed is provided in meters per second (m/s)
                    labPressure.Text = Info.main.pressure.ToString(); 
                }
                catch (WebException ex)
                {
                    // Handling network errors
                    MessageBox.Show("Network error while retrieving weather data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (JsonException ex)
                {
                    // Handling JSON deserialization errors
                    MessageBox.Show("JSON deserialization error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handling other unexpected errors
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Method to convert Unix timestamp to DateTime
        DateTime convertDateTime(long sec)
        {
            // Year, month, day, hour, minute, second, millisecond
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day; 
        }
    }
}
