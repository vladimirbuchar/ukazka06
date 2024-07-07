using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace EduApi
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
            var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetService(jobType);
        }
    }
}
