using Microsoft.AspNetCore.Mvc;
using Model_Class.Models;

namespace Model_Class.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/{bookid?}/{isLoggedin?}")]
        public IActionResult Index([FromQuery]int? bookId, bool? isloggedin, Book book) // deafult action method named Index conventionally
        {
            if (!isloggedin.HasValue || isloggedin == false )
            {
                return Unauthorized("User must be authenticated");
            }

            if(!bookId.HasValue)
            {
                return BadRequest("Book id is not supplied");
            }
            if (bookId <= 0)
            {
                return BadRequest("Book id cannot be less than or equal zero");
            }

            if(bookId > 1000)
            {
                return NotFound("Book id cannot be greater than 1000");
            }


            return Content($"Book {bookId} Book Class{book}");
            
        }
    }
}
