using Hangfire;

namespace HangfireApi.Configuration.Hangfire
{
    public class ScopedJobActivator : JobActivator
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedJobActivator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override object ActivateJob(Type jobType)
        {
            IServiceScope scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetService(jobType);
        }
    }
}
