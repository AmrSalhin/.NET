using Microsoft.AspNetCore.Mvc;
using RazorViewAssignment.Models;

namespace RazorViewAssignment.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> cityWeathers = new List<CityWeather>()
        { 
            new CityWeather{CityUniqueCode = "LDN", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33, CityName = "London" },
            new CityWeather{CityUniqueCode = "NYC", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60, CityName = "NEW YORK" },
            new CityWeather{ CityUniqueCode = "PAR", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82, CityName = "PARIS" }
        };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cityWeathers);
        }

        [Route("weather/{CityCode}")]
        public IActionResult Details (string CityCode)
        {
            foreach(CityWeather cityWeather in cityWeathers)
            {
                if(cityWeather.CityUniqueCode == CityCode.ToUpper())
                {
                    return View(cityWeather);
                }
            }
            return Content("Cannot find this City");
        }
    }
}
