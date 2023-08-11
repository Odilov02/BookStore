using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers;

public class BookController : Controller
{
    [Authorize]
    public IActionResult CreateBook()=> View();
 
    [HttpPost]
    public IActionResult CreateBook(CreateBookCommand command)
    {
        return View();
    }

    public IActionResult GetAllBook() => View();
}
