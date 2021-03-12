using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace PointOfSale.Infrastructure.DataAccess
{
    public class PointOfSaleContainer : IPointOfSaleContainer
    {
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
