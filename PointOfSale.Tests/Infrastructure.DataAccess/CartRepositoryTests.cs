using PointOfSale.Domain.Core.Entities;
using PointOfSale.Infrastructure.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PointOfSale.Tests.Infrastructure.DataAccess
{
    public class CartRepositoryTests
    {
        PointOfSaleContainer container;

        CartRepository cartRepository;

        public CartRepositoryTests()
        {
            container = new PointOfSaleContainer();

            cartRepository = new CartRepository(container);

            container.CartLines = new List<CartLine>
            {
                new CartLine { Product = new Product { Code = "A", RetailPrice = 1.25m, VolumePrice = 3m, VolumeQuantity = 3 }, Quantity = 1},
                new CartLine { Product = new Product { Code = "B", RetailPrice = 4.25m }, Quantity = 2},
                new CartLine { Product = new Product { Code = "C", RetailPrice = 1m, VolumePrice = 5m, VolumeQuantity = 6 }, Quantity = 3},
                new CartLine { Product = new Product { Code = "D", RetailPrice = 0.75m}, Quantity = 4}
            };
        }

        [Fact]
        public void AddItem_ShouldAddItems()
        {
            var product = new Product
            {
                Code = "E",
                RetailPrice = 10
            };

            var cartLine = new CartLine
            {
                Product = product,
                Quantity = 5
            };

            cartRepository.AddItem(cartLine);

            Assert.Equal(cartLine, container.CartLines.First(c => c.Product.Code == "E"));
        }

        [Fact]
        public void GetByCode_ShouldGetRightCartLine()
        {
            string productCode = "C";
            var expected = container.CartLines.First(c => c.Product.Code == productCode);

            var result = cartRepository.GetByCode(productCode);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAll_ShouldReturnAll()
        {
            var expected = container.CartLines;

            var result = cartRepository.GetAll();

            Assert.Equal(expected, result);
        }

    }
}
