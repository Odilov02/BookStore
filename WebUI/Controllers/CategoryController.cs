using MediatR;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) => _mediator = mediator;

        public IActionResult CreateCategory() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result) RedirectToAction("GetAllCategory");
            return View();
        }

        public IActionResult GetAllCategory() => View();
    }
}
