using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace PointOfScale.Infrastructure.DataAccess
{
    public class PointOfScaleContainer : IPointOfScaleContainer
    {
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
