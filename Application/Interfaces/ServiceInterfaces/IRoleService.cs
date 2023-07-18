using Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IRoleService : IRepository<IdentityRole>
    {

    }
}
