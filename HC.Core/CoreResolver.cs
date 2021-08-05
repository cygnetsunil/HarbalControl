using HC.Core.Interface;
using HC.Core.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HC.Core
{
    public static class CoreResolver
    {
        public static IServiceCollection AddCoreDependency(this IServiceCollection services)
        {
            services.AddTransient<IBoatTypeManager, BoatTypeManager>();
            return services;
        }
    }
}
