using Application.UseCases.Users.Command.CreateUser;
using Application.UseCases.Users.Command.UpdateUser;

namespace Application.Comman.Mappings;

public class UserMapping : Profile
{
    public UserMapping() => UserMap();

    void UserMap()
    {
        CreateMap<UpdateUserCommand, User>();
        CreateMap<CreateUserCommand, User>();
    }
}
