namespace Application.UseCases.Categories.Command.UpdateCategory;
#nullable disable
public class UpdateCategoryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;
    public UpdateCategoryCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (category is null) throw new NotFoundException();
        category.Description = request.Description;
        category.Name = request.Name;
        _dbContext.Categories.Update(category);
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}

