using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using PointOfSale.Domain.Interfaces.Services;
using System.Linq;

namespace PointOfSale.Domain.Services.Services
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
            var cartLines = _repo.GetAll();

            return cartLines.Sum((p) =>
            {
                if (p.Product.VolumeQuantity != 0)
                {
                    return p.Quantity / p.Product.VolumeQuantity * p.Product.VolumePrice
                    + p.Quantity % p.Product.VolumeQuantity * p.Product.RetailPrice;
                }
                else
                {
                    return p.Product.RetailPrice * p.Quantity;
                }
            });

        }
    }
}
