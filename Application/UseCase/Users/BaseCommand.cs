using Application.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Users
{
    public abstract class BaseCommand
    {
        protected readonly IUserService _userService;

        public BaseCommand(IUserService userService)
        {
            _userService = userService;
        }
    }
}
