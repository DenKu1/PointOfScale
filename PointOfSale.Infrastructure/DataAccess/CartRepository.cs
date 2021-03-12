using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Infrastructure.DataAccess
{
    public class CartRepository : ICartRepository
    {
        private readonly IPointOfSaleContainer _container;

        public CartRepository(IPointOfSaleContainer pointOfSaleContainer)
        {
            _container = pointOfSaleContainer;
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

        public List<CartLine> GetAll()
        {
            return _container.CartLines;
        }
    }
}
