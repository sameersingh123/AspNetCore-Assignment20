using Assignment20.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment20.Controllers
{
    public class HomeController : Controller
    {
        public List<CityWeather> cityWeather = new List<CityWeather>()
        {
            new CityWeather{CityUniqueCode="LDN", CityName="London", DateAndTime= Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit=33},
            new CityWeather{CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
            new CityWeather{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
        };

        [Route("/")]
        public IActionResult Index()
        {
            return View(cityWeather);
        }


        [Route("/weather/{cityCode}")]
        public IActionResult City(string cityCode)
        {
            if (cityCode == null)
            {
                return View();
            }

            CityWeather? matchingCity=cityWeather.Where(temp=>temp.CityUniqueCode== cityCode).FirstOrDefault();

            return View(matchingCity);
        }
    }
}
