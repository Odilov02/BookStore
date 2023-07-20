using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Users
{
    public class LogOutCommand:IRequest<bool>
    {

    }
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, bool>
    {
        private readonly SignInManager<User> _signInManager;

        public LogOutCommandHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
           await _signInManager.SignOutAsync();
            return true;
        }
    }
}
