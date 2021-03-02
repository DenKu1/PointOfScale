using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using PointOfScale.Domain.Interfaces.Services;

namespace PointOfScale.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;

        public CartService(ICartRepository repository)
        {
            _repo = repository;
        }

        public void AddItem(Product product)
        {
            CartLine line = _repo.GetByCode(product.Code);            

            if (line == null)
            {
                _repo.AddItem(new CartLine
                {
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                line.Quantity += 1;
            }
        }

        public decimal CalculateTotal()
        {
            return _repo.SumPrice();
        }
    }
}
