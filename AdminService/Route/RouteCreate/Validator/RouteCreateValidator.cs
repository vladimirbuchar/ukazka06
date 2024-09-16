using AdminService.Route.RouteCreate.Dto;
using Core.Base.Validator;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteCreate.Validator
{
    public class RouteCreateValidator : BaseCreateValidator<RouteDbo, IRouteRepository, RouteCreateDto>, IRouteCreateValidator
    {
        public RouteCreateValidator(IRouteRepository repository)
            : base(repository) { }
    }
}
