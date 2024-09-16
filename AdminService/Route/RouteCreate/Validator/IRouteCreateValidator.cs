using AdminService.Route.RouteCreate.Dto;
using Core.Base.Validator;
using Model.System;

namespace AdminService.Route.RouteCreate.Validator
{
    public interface IRouteCreateValidator : IBaseCreateValidator<RouteDbo, RouteCreateDto> { }
}
