using MediatR;
using MillionWebApi.Features.Peoples.Get;
using MillionWebApi.Features.Peoples.GetById;

namespace MillionWebApi.Endpoints;

public static class PeopleEndpoints
{
    const string PATH = "api/people/";

    public static IEndpointRouteBuilder MapPeoples(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet(PATH + "{id}", async (int id, ISender sender, CancellationToken cancellationToken = default)
            => await sender.Send(new GetPeopleByIdRequest(id), cancellationToken)).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(1))); ;

        endpoint.MapGet(PATH + "skip={_skip}/take={_take}", async (int _skip, int _take, ISender sender, CancellationToken cancellationToken = default)
            => await sender.Send(new GetPeoplesRequest(_skip, _take), cancellationToken)).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(1)));

        return endpoint;
    }
}
