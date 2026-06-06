using Microsoft.AspNetCore.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index(List<Person> Person)
        {
            /*Dummy Data to display in case no data sent in request*/
            Person.Add(new() { Name = "john", DateOfBirth = new DateTime(2000,1,1),Gender = Gender.Male });
            Person.Add(new() { Name = "Alexa", DateOfBirth = new DateTime(2004,5,30),Gender = Gender.Female });
            ViewData["AppTitle"] = "ASP.net Application";
            ViewData["Pepole"] = Person;
            return View();
        }

        [Route("Person-Details/{name}")]
        public IActionResult Details(string name)
        {
            if (name == null)
                return Content("No name Supplied");

            List<Person> pepole = new List<Person>();
            pepole.Add(new() { Name = "john", DateOfBirth = new DateTime(2000, 1, 1), Gender = Gender.Male });
            pepole.Add(new() { Name = "Alexa", DateOfBirth = new DateTime(2004, 5, 30), Gender = Gender.Female });

            Person? matchedPerson = pepole.Where(item =>  item.Name == name).FirstOrDefault();
            return View(matchedPerson);
        }
    }
}
