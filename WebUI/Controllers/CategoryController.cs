using Application.UseCases.Categories.Command.DeleteCategory;
using Application.UseCases.Categories.Query.GetAllCategory;
using Application.UseCases.Categories.Query.GetCategory;
using AutoMapper;
using MediatR;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));
            return View(result);
        }


        public async Task<IActionResult> GetAllCategory(int pageSize = 5, int PageIndex = 1)
        {
            var result = await _mediator.Send(new GetAllCategoryQuery(pageSize, PageIndex));
            return View(result);
        }

        public IActionResult CreateCategory() => View();
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result) return RedirectToAction("GetAllCategory");
            else return View();
        }

        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            Category category = await _mediator.Send(new GetCategoryQuery(id));
            UpdateCategoryCommand result = _mapper.Map<UpdateCategoryCommand>(category);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result) return RedirectToAction("GetAllCategory", "Category");
            return View(command);
        }
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(category.Id));
            if (result) return RedirectToAction("GetAllCategory");
            return RedirectToAction("DeleteCategory", category.Id); ;
        }
    }
}
