using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.System;

namespace EduRepository.RouteRepository
{
    public class RouteRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<RouteDbo>(dbContext, memoryCache), IRouteRepository
    {

    }
}
