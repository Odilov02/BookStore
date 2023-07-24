
namespace Application.UseCases.Authors.Command.CreateAuthor;

public class CreateAuthorCommand : IRequest<bool>
{
    public string FullName { get; set; }

    public string ImgUrl { get; set; }

    public string Description { get; set; }
}

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;


    public CreateAuthorCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(request);
        if (author == null) return false;
        await _dbContext.Authors.AddAsync(author, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
