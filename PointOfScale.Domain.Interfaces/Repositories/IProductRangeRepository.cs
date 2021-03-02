using PointOfScale.Domain.Core.Entities;
using System.Collections.Generic;

namespace PointOfScale.Domain.Interfaces.Repositories
{
    public interface IProductRangeRepository
    {
        Product GetByCode(string productCode);

        void LoadProducts(IEnumerable<Product> products);
    }
}
