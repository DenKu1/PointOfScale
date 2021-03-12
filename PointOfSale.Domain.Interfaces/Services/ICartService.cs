using PointOfSale.Domain.Core.Entities;

namespace PointOfSale.Domain.Interfaces.Services
{
    public interface ICartService
    {
        void AddItem(Product product);

        decimal CalculateTotal();
    }
}
