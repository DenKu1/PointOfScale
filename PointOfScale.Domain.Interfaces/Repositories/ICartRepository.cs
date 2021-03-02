using PointOfScale.Domain.Core.Entities;

namespace PointOfScale.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        void AddItem(CartLine cartLine);

        CartLine GetByCode(string productCode);

        decimal SumPrice();
    }
}
