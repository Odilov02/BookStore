namespace Application.UseCases.Books.Query.GetAllBook;

public class GetAllBookQuery : IRequest<PaginatedList<Book>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, PaginatedList<Book>>
{
    private readonly IApplicatonDbcontext _dbContext;
    public GetAllBookQueryHandler(IApplicatonDbcontext dbContext) => _dbContext = dbContext;
    public Task<PaginatedList<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        var books = _dbContext.Books.ToList();
        var result = PaginatedList<Book>.Create(books, request.PageSize, request.PageIndex);
        return Task.FromResult(result);
    }
}
