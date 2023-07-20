using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extentions;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCase.Users
{
    public class CreateUserCommand:IRequest<User>
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    public class CreateCommandHandler : BaseCommand, IRequestHandler<CreateUserCommand, User>
    {
        public CreateCommandHandler(IUserService userService)
            :base(userService)
        {
            
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = request.Password.stringHash(),

            };
            var result =await _userService.AddAsync(user);
            return result;
        }
    }
}
