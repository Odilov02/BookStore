namespace Application.UseCases.Categories.Command.CreateCategory;

public class CreateCategoryCommand : IRequest<bool>
{
    public string name { get; set; }
    public string Descraption { get; set; }
}
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IApplicatonDbcontext _dbContext;

    public CreateCategoryCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = _mapper.Map<Category>(request);
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
