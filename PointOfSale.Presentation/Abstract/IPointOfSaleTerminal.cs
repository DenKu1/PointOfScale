using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Abstract
{
    public interface IPointOfSaleTerminal
    {
        decimal CalculateTotal();

        void Scan(string productCode);

        void SetPricing(IEnumerable<ProductModel> productModels);
    }
}
