using PointOfSale.Domain.Core.Entities;
using System.Collections.Generic;

namespace PointOfSale.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        void AddItem(CartLine cartLine);

        CartLine GetByCode(string productCode);

        List<CartLine> GetAll();
    }
}
