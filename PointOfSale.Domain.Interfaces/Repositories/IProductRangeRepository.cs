using PointOfSale.Domain.Core.Entities;
using System.Collections.Generic;

namespace PointOfSale.Domain.Interfaces.Repositories
{
    public interface IProductRangeRepository
    {
        Product GetByCode(string productCode);

        void LoadProducts(IEnumerable<Product> products);
    }
}
