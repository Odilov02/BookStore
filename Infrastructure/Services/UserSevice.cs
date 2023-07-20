using Application.Abstraction;
using Application.Models;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces.ServiceInterfaces;

public class UserSevice: IUserService
{
    UserManager<User> _userManager;
    public UserSevice(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> AddAsync(User entity)
    {
        await _userManager.CreateAsync(entity);
        return entity;
    }

    public async Task<ICollection<User>> AddRangeAsync(ICollection<User> entities)
    {
        foreach (var entity in entities)
        {
            await _userManager.CreateAsync(entity);
        }
        return entities;
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        var result = await _userManager.DeleteAsync(entity);
        return result.Succeeded;

    }

    public async Task<User> Get(Guid Id)
    {
        var result =  _userManager.Users.ToList().FirstOrDefault(x => x.Id == Id.ToString());
        return result;
    }

    public async Task<List<User>> GetAll()
    {
        var result = _userManager.Users.ToList();
        return result;
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        var result = await _userManager.UpdateAsync(entity);
        return result.Succeeded;
    }

}