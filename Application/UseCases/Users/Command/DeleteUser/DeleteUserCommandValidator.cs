﻿namespace Application.UseCases.Users.Command.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.");
    }
}
