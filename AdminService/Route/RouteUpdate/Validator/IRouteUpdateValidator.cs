using AdminService.Route.RouteUpdate.Dto;
using Core.Base.Validator;
using Model.System;

namespace AdminService.Route.RouteUpdate.Validator
{
    public interface IRouteUpdateValidator : IBaseUpdateValidator<RouteDbo, RouteUpdateDto>
    {
    }
}