using PointOfScale.Domain.Core.Entities;
using System.Collections.Generic;

namespace PointOfScale.Domain.Interfaces.Repositories
{
    public interface IPointOfScaleContainer
    {
        List<CartLine> CartLines { get; set; }

        List<Product> Products { get; set; }
    }
}
