using AdminService.Route.RouteUpdate.Dto;
using Model.System;

namespace AdminService.Route.RouteUpdate.Convertor
{
    public class RouteUpdateConvertor : IRouteUpdateConvertor
    {
        public Task<RouteDbo> ConvertToBussinessEntity(RouteUpdateDto update, RouteDbo entity, string culture)
        {
            entity.Route = update.Route;
            return Task.FromResult(entity);
        }
    }
}
