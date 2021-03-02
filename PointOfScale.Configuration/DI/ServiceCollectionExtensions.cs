using Microsoft.Extensions.DependencyInjection;
using PointOfScale.Domain.Interfaces.Repositories;
using PointOfScale.Domain.Interfaces.Services;
using PointOfScale.Infrastructure.DataAccess;
using PointOfScale.Infrastructure.Services;
using PointOfScale.Presentation.Abstract;
using PointOfScale.Presentation.Concrete;

namespace PointOfScale.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPointOfScale(this IServiceCollection services)
        {
            services.AddSingleton<IPointOfScaleContainer, PointOfScaleContainer>();

            services.AddSingleton<ICartRepository, CartRepository>();
            services.AddSingleton<IProductRangeRepository, ProductRangeRepository>();

            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IProductRangeService, ProductRangeService>();

            services.AddSingleton<IPointOfSaleTerminal, PointOfSaleTerminal>();
        }
    }
}
