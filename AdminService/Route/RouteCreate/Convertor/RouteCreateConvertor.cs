using AdminService.Route.RouteCreate.Dto;
using Model.System;

namespace AdminService.Route.RouteCreate.Convertor
{
    public class RouteCreateConvertor : IRouteCreateConvertor
    {
        public Task<RouteDbo> ConvertToBussinessEntity(RouteCreateDto create, string culture)
        {
            return Task.FromResult(new RouteDbo() { Route = create.Route });
        }
    }
}
