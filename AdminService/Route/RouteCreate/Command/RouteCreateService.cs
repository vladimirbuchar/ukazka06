using AdminService.Route.RouteCreate.Convertor;
using AdminService.Route.RouteCreate.Dto;
using AdminService.Route.RouteCreate.Validator;
using Core.Base.Command.Create;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteCreate.Command
{
    public class RouteCreateService
        : BaseCreateCommand<RouteDbo, IRouteRepository, RouteCreateDto, IRouteCreateConvertor, IRouteCreateValidator>,
            IRouteCreateService
    {
        public RouteCreateService(IRouteRepository repository, IRouteCreateConvertor convertor, IRouteCreateValidator validator)
            : base(repository, convertor, validator) { }
    }
}
