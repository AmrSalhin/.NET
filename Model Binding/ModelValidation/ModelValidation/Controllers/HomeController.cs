using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values.SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage).ToList());
                //foreach(var value in ModelState.Values)
                //{
                //    foreach(var error in value.Errors)
                //    {
                //        errorsMessage.Add(error.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorsMessage);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
