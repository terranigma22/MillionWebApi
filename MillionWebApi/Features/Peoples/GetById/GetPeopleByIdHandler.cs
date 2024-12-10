using MediatR;
using Microsoft.EntityFrameworkCore;
using MillionWebApi.Data;
using MillionWebApi.Domain;

namespace MillionWebApi.Features.Peoples.GetById;

public record GetPeopleByIdRequest(int id) : IRequest<People?>;

public class GetPeopleByIdHandler : IRequestHandler<GetPeopleByIdRequest, People?>
{
    private readonly DataContext context;

    public GetPeopleByIdHandler(DataContext context)
    {
        this.context = context;
    }
    public async Task<People?> Handle(GetPeopleByIdRequest request, CancellationToken cancellationToken)
    {
        return await context.Peoples.Where(p => p.Id == request.id).FirstOrDefaultAsync(cancellationToken);
    }
}
