using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace WeatherApplication.Controllers
{
    public class WeatherController : Controller
    {
        public ActionResult WeatherApplication()
        {
            string forecast = "";
            WebClient client = new WebClient();
            forecast = client.DownloadString("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            dynamic jobject = JObject.Parse(forecast);
            var wind = jobject.wind.speed;
            var location = jobject.name;
            var weather = jobject.weather[0].description;
            ViewData["WeatherLocation"] = location;
            ViewData["Weatherweather"] = weather;
            ViewData["Weatherwind"] = wind;
            return View();
        }
    }
}