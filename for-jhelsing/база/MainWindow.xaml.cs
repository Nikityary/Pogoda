using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using static System.Net.WebRequestMethods;

namespace база
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string q = Text1.Text;
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" + q + "&lang=ru&APPID=24675dcb634e0fd2513da5d3f09b9d74");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();
            OpenWeather OW = JsonConvert.DeserializeObject<OpenWeather>(answer);
            Davlenie.Content = "Давление: " + ((int)OW.main.pressure).ToString() + " мм";
            Wind_Speed.Content = "Скорость ветра: " + OW.wind.speed.ToString() + " м/с";
            Humidity.Content = "Влажность: " + OW.main.humidity.ToString() + "%";
            Temp.Content = OW.main.temp.ToString("0.##") + "°C";
            City.Content = OW.name.ToString();
            switch (OW.weather[0].icon)
            {
                case "01d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/yasno.png", UriKind.Relative));
                        WeatherType.Content = "Ясно";
                        break;
                    }
                case "01n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/night.png", UriKind.Relative));
                        WeatherType.Content = "Ясно";
                        break;
                    }
                case "02d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mini_oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Небольшая облачность";
                        break;
                    }
                case "02n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mini_oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Небольшая облачность";
                        break;
                    }
                case "03d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Облачно";
                        break;
                    }
                case "03n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Облачно";
                        break;
                    }
                case "04d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Сильная облачность";
                        break;
                    }
                case "04n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Сильная облачность";
                        break;
                    }
                case "09d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mega_rain.png", UriKind.Relative));
                        WeatherType.Content = "Сильный дождь";
                        break;
                    }
                case "09n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mega_rain.png", UriKind.Relative));
                        WeatherType.Content = "Сильный дождь";
                        break;
                    }
                case "10d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/rain.png", UriKind.Relative));
                        WeatherType.Content = "Дождь";
                        break;
                    }
                case "10n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/rain.png", UriKind.Relative));
                        WeatherType.Content = "Дождь";
                        break;
                    }
                case "11d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/thunder.png", UriKind.Relative));
                        WeatherType.Content = "Гроза";
                        break;
                    }
                case "11n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/thunder.png", UriKind.Relative));
                        WeatherType.Content = "Гроза";
                        break;
                    }
                case "13d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/snow.png", UriKind.Relative));
                        WeatherType.Content = "Снег";
                        break;
                    }
                case "13n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/snow.png", UriKind.Relative));
                        WeatherType.Content = "Снег";
                        break;
                    }
                case "50d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/tuman.png", UriKind.Relative));
                        WeatherType.Content = "Туман";
                        break;
                    }
                case "50n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/tuman.png", UriKind.Relative));
                        WeatherType.Content = "Туман";
                        break;
                    }
            }
        }

    }
}
