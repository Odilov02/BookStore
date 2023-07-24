namespace Application.UseCases.Commentaries.Query.GetCommentary;

public class GetAllCommentaryCommand : IRequest<PaginatedList<Commentary>>
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}

public class GetAllCommentaryCommentaryHandler : IRequestHandler<GetAllCommentaryCommand, PaginatedList<Commentary>>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetAllCommentaryCommentaryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public Task<PaginatedList<Commentary>> Handle(GetAllCommentaryCommand request, CancellationToken cancellationToken)
    {
        var commentaries = _dbcontext.Commentaries.ToList();
        var result = PaginatedList<Commentary>.Create(commentaries, request.PageSize, request.PageIndex);
        return Task.FromResult(result);
    }
}
