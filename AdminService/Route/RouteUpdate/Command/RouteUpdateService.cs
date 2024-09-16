using AdminService.Route.RouteUpdate.Convertor;
using AdminService.Route.RouteUpdate.Dto;
using AdminService.Route.RouteUpdate.Validator;
using Core.Base.Command.Update;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteUpdate.Command
{
    public class RouteUpdateService : BaseUpdateCommand<RouteDbo, IRouteRepository, RouteUpdateDto, IRouteUpdateConvertor, IRouteUpdateValidator>, IRouteUpdateService
    {
        public RouteUpdateService(IRouteRepository repository, IRouteUpdateConvertor convertor, IRouteUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
