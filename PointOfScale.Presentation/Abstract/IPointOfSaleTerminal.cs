using PointOfScale.DTOs;
using System.Collections.Generic;

namespace PointOfScale.Presentation.Abstract
{
    public interface IPointOfSaleTerminal
    {
        decimal CalculateTotal();

        void Scan(string productCode);

        void SetPricing(IEnumerable<ProductDTO> productDTOs);
    }
}
