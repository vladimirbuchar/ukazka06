using AdminService.Route.RouteUpdate.Dto;
using Core.Base.Validator;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteUpdate.Validator
{
    public class RouteUpdateValidator : BaseUpdateValidator<RouteDbo, IRouteRepository, RouteUpdateDto>, IRouteUpdateValidator
    {
        public RouteUpdateValidator(IRouteRepository repository) : base(repository)
        {
        }
    }
}
