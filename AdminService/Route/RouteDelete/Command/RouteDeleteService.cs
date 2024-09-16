using Core.Base.Command.Delete;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteDelete.Command
{
    public class RouteDeleteService : BaseDeleteCommand<RouteDbo, IRouteRepository>, IRouteDeleteService
    {
        public RouteDeleteService(IRouteRepository repository) : base(repository)
        {
        }
    }
}
