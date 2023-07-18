using Application.Extentions;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCase.Users
{
    public class LoginCommand : IRequest<bool>
    {
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Compare("password")]
        public string conformPassword { get; set; }
    }

    public class LoginCommondHandler : BaseCommand, IRequestHandler<LoginCommand, bool>
    {
        private readonly SignInManager<User> _signInManager;

        public LoginCommondHandler(IUserService userService, SignInManager<User> signInManager)
            : base(userService)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = (await _userService.GetAll()).FirstOrDefault(x => x.Email == request.email&&x.PasswordHash==request.password.stringHash());
            if (user == null) return false;
            await _signInManager.SignInAsync(user!, true);
            return true;
        }
    }
}
