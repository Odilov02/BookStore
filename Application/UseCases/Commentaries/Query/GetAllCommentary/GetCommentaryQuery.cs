namespace Application.UseCases.Commentaries.Query.GetAllCommentary;

public class GetCommentaryQuery : IRequest<Commentary?>
{
    public Guid Id { get; set; }
}
public class GetCommentaryQueryHandler : IRequestHandler<GetCommentaryQuery, Commentary?>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetCommentaryQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<Commentary?> Handle(GetCommentaryQuery request, CancellationToken cancellationToken)
    {
        var commentary = await _dbcontext.Commentaries.FirstOrDefaultAsync(x => x.Id == request.Id);
        return commentary;
    }
}