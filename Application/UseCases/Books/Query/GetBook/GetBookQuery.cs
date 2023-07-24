﻿namespace Application.UseCases.Books.Query.GetBook;

public class GetBookQuery : IRequest<Book?>
{
    public Guid Id { get; set; }
}
public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book?>
{
    private readonly IApplicatonDbcontext _dbcontext;
    public GetBookQueryHandler(IApplicatonDbcontext dbcontext) => _dbcontext = dbcontext;
    public async Task<Book?> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _dbcontext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);
        return book;
    }
}