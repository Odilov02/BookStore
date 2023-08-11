using Application.Comman.Extentions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManiger;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, UserManager<User> userManiger, IMediator mediator)
        {
            _mapper = mapper;
            _userManiger = userManiger;
            _mediator = mediator;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);
            user.Password = user.Password.stringHash();
            var result =await _userManiger.CreateAsync(user);
            if (result.Succeeded) return View("Login");
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginUserCommand command)
        {
           // var result = _mediator.Send(command);
          //  if (result.Result)
                return RedirectToAction("CreateBook", "Book");
           // return View();
        }

    }
}
