namespace WebUI.Controllers;

public class AuthorController : Controller
{
    public IActionResult CreateAuthor() => View();

    [HttpPost]
    public IActionResult CreateAuthor(CreateAuthorCommand command)
    {
        return View();
    }

    public IActionResult GetAllAuthor() => View();
}
