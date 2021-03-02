using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using System.Linq;

namespace PointOfScale.Infrastructure.DataAccess
{
    public class CartRepository : ICartRepository
    {
        private readonly IPointOfScaleContainer _container;

        public CartRepository(IPointOfScaleContainer pointOfScaleContainer)
        {
            _container = pointOfScaleContainer;
        }

        public void AddItem(CartLine cartLine)
        {
            _container.CartLines.Add(cartLine);
        }

        public CartLine GetByCode(string productCode)
        {
            return _container
                .CartLines
                .Where(p => p.Product.Code == productCode)
                .FirstOrDefault();
        }

        public decimal SumPrice()
        {
            return _container
                .CartLines
                .Sum(line => line.CalculatePrice());
        }
    }
}
