using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.IoC
{
    // By using this class we can get the opposite class of an Interface
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
