namespace Application.Comman.Interfaces;

public interface IUserManigerService<TUser> 
{
    Task<IdentityResult> CreateAsync(TUser user);
}

