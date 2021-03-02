using PointOfScale.Domain.Core.Entities;
using PointOfScale.DTOs;
using System.Collections.Generic;

namespace PointOfScale.Domain.Interfaces.Services
{
    public interface IProductRangeService
    {
        Product GetByCode(string productCode);

        void LoadProducts(IEnumerable<ProductDTO> productDTOs);
    }
}
