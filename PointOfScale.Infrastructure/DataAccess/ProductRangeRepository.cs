using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PointOfScale.Infrastructure.DataAccess
{
    public class ProductRangeRepository : IProductRangeRepository
    {
        private readonly IPointOfScaleContainer _container;

        public ProductRangeRepository(IPointOfScaleContainer pointOfScaleContainer)
        {
            _container = pointOfScaleContainer;
        }

        public Product GetByCode(string productCode)
        {
            return _container
                .Products
                .FirstOrDefault(p => p.Code == productCode);
        }

        public void LoadProducts(IEnumerable<Product> products)
        {
            _container.Products = products.ToList();
        }
    }
}
