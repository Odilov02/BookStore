namespace Application.UseCases.Authors.Command.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public string ImgUrl { get; set; }

    public string Description { get; set; }
}
public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(request);
        if (author is null) return false;
        if (await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == author.Id) is null) return false;
        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
