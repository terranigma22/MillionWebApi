using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MillionWebApi.Data;
using MillionWebApi.Domain;

namespace MillionWebApi.Features.Peoples.Get;

public record GetPeoplesRequest(int skip = 0, int take = 20) : IRequest<IEnumerable<People>>;

public class GetPeoplesHandler : IRequestHandler<GetPeoplesRequest, IEnumerable<People>>
{
    private readonly DataContext context;

    public GetPeoplesHandler(DataContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<People>> Handle(GetPeoplesRequest request, CancellationToken cancellationToken)
    {
        return await context.Peoples
        .Skip(request.skip)
        .Take(request.take)
        .ToListAsync(cancellationToken);
    }
}
