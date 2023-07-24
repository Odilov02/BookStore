namespace Application.UseCases.Books.Command.DeleteBook;

public class DeleteBookCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    public DeleteBookCommandHandler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (book == null) return false;
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}