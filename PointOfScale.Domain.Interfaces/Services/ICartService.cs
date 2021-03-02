using PointOfScale.Domain.Core.Entities;

namespace PointOfScale.Domain.Interfaces.Services
{
    public interface ICartService
    {
        void AddItem(Product product);

        decimal CalculateTotal();
    }
}
