﻿namespace Application.UseCases.Commentaries.Command.UpdateCommentary;

public class UpdateCommentaryCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Guid BookId { get; set; }
    public string UserId { get; set; }
}
public class UpdateCommentaryCommandHandler : IRequestHandler<UpdateCommentaryCommand, bool>
{
    private readonly IApplicatonDbcontext _dbContext;
    private readonly IMapper _mapper;

    public UpdateCommentaryCommandHandler(IApplicatonDbcontext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCommentaryCommand request, CancellationToken cancellationToken)
    {
        var commentary = _mapper.Map<Commentary>(request);
        if (commentary == null) return false;
        if (await _dbContext.Commentaries.FirstOrDefaultAsync(x => x.Id == commentary.Id) is null) return false;
        _dbContext.Commentaries.Update(commentary);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
