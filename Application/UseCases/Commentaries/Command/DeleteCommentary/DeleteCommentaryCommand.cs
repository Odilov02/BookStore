namespace Application.UseCases.Commentaries.Command.DeleteCommentary;

public class DeleteCommentaryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
public class DeleteCommentaryCommandHandler : IRequestHandler<DeleteCommentaryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public DeleteCommentaryCommandHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<bool> Handle(DeleteCommentaryCommand request, CancellationToken cancellationToken)
    {
        var commentary = await _dbcontext.Commentaries.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (commentary == null) return false;
        _dbcontext.Commentaries.Remove(commentary);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
