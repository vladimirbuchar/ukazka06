using AdminService.Route.RouteList.Dto;
using Model.System;

namespace AdminService.Route.RouteList.Convertor
{
    public class RouteListConvertor : IRouteListConvertor
    {
        public Task<List<RouteListDto>> ConvertToWebModel(List<RouteDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new RouteListDto() { Id = item.Id, Route = item.Route, }).ToList());
        }
    }
}
