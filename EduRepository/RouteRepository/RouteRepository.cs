using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.System;

namespace Repository.RouteRepository
{
    public class RouteRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<RouteDbo>(dbContext, memoryCache),
            IRouteRepository { }
}
