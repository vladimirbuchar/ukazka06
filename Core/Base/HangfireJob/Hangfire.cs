using Microsoft.Extensions.DependencyInjection;

namespace Core.Base.HangfireJob
{
    public abstract class Hangfire(IServiceScopeFactory serviceScopeFactory)
    {
        protected IServiceScope _scope = serviceScopeFactory.CreateScope();

        public abstract void Execute();

    }
}
