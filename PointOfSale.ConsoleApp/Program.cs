using Microsoft.Extensions.DependencyInjection;
using PointOfSale.Configuration.DI;
using PointOfSale.ConsoleApp.Main;
using System;

namespace PointOfSale.ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main()
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ConsoleApplication>();
            services.AddPointOfSale();

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

    }
}
