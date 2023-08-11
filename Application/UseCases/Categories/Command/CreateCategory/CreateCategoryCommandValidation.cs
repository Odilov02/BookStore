namespace Application.UseCases.Categories.Command.CreateCategory;

public class CreateCategoryCommandValidation:AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidation()
    {
        RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x=>x.Description).NotEmpty().MaximumLength(500);
    }
}
