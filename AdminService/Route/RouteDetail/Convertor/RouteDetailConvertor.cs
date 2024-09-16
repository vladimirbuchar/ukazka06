using AdminService.Route.RouteDetail.Dto;
using Model.System;

namespace AdminService.Route.RouteDetail.Convertor
{
    public class RouteDetailConvertor : IRouteDetailConvertor
    {
        public Task<RouteDetailDto> ConvertToWebModel(RouteDbo detail, List<string> culture)
        {
            return Task.FromResult(new RouteDetailDto() { Id = detail.Id, Route = detail.Route });
        }
    }
}
