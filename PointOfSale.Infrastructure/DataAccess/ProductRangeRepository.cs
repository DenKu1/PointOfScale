using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Infrastructure.DataAccess
{
    public class ProductRangeRepository : IProductRangeRepository
    {
        private readonly IPointOfSaleContainer _container;

        public ProductRangeRepository(IPointOfSaleContainer pointOfSaleContainer)
        {
            _container = pointOfSaleContainer;
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
