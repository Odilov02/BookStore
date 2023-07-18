using Application.UseCase.Users;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediatR;
        private readonly UserManager<User> _userManager;

        public UserController(IMediator mediatR,UserManager<User> userManager)
        {
            _mediatR = mediatR;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            await _mediatR.Send(loginCommand);
            return View();
        }
    }
}
