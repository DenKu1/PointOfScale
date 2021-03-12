using PointOfSale.Domain.Core.Entities;
using System.Collections.Generic;

namespace PointOfSale.Domain.Interfaces.Repositories
{
    public interface IPointOfSaleContainer
    {
        List<CartLine> CartLines { get; set; }

        List<Product> Products { get; set; }
    }
}
