using Core.Base.Command.Restore;
using Model.System;
using Repository.Route;

namespace AdminService.Route.RouteRestore.Command
{
    public class RouteRestoreService : BaseRestoreCommand<RouteDbo, IRouteRepository>, IRouteRestoreService
    {
        public RouteRestoreService(IRouteRepository repository) : base(repository)
        {
        }
    }
}
