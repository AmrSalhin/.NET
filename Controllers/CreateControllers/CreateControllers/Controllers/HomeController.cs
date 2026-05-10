using Microsoft.AspNetCore.Mvc;

namespace CreateControllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index() // deafult action method named Index conventionally
        {
            if (Convert.ToBoolean(Request.Query["isloggedIn"]) == false)
            {
                return Unauthorized("User must be authenticated");
            }

            if(!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Book id is not supplied");
            }

            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book id cannot be null or empty");
            }

            int book = Convert.ToInt32(Request.Query["bookid"]);
            if (book <= 0)
            {
                return BadRequest("Book id cannot be less than or equal zero");
            }

            if(book > 1000)
            {
                return NotFound("Book id cannot be greater than 1000");
            }


            return Content($"Book {book}");
            
        }
    }
}
