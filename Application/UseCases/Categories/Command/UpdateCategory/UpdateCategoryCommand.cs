namespace Application.UseCases.Categories.Command.UpdateCategory;

public class UpdateCategoryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public string Descraption { get; set; }
}
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper = null)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }



    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        if (category == null) return false;
        if (_dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id) is null) return false;
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

