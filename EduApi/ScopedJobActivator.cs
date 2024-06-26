﻿using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            return scope.ServiceProvider.GetRequiredService(jobType);
        }
    }
}
