using Microsoft.Extensions.DependencyInjection;
using PointOfSale.Domain.Interfaces.Repositories;
using PointOfSale.Domain.Interfaces.Services;
using PointOfSale.Domain.Services.Services;
using PointOfSale.Infrastructure.DataAccess;
using PointOfSale.Presentation.Abstract;
using PointOfSale.Presentation.Concrete;

namespace PointOfSale.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPointOfSale(this IServiceCollection services)
        {
            services.AddSingleton<IPointOfSaleContainer, PointOfSaleContainer>();

            services.AddSingleton<ICartRepository, CartRepository>();
            services.AddSingleton<IProductRangeRepository, ProductRangeRepository>();

            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IProductRangeService, ProductRangeService>();

            services.AddSingleton<IPointOfSaleTerminal, PointOfSaleTerminal>();
        }
    }
}
