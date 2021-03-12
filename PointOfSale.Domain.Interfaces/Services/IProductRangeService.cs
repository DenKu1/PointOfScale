using PointOfSale.Domain.Core.Entities;
using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale.Domain.Interfaces.Services
{
    public interface IProductRangeService
    {
        Product GetByCode(string productCode);

        void LoadProducts(IEnumerable<ProductModel> productModels);
    }
}
