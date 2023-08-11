using System.ComponentModel;

namespace Application.UseCases.Users.Command.Login;

public class LoginUserCommand : IRequest<bool>
{
    public string UserName { get; set; }
    [PasswordPropertyText]
    public string Password { get; set; }
}
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.UserName == request.UserName && x.Password == request.Password.stringHash());
        if (user == null) throw new NotFoundException();
        await _signInManager.SignInAsync(user, true);
        return true;
    }
}