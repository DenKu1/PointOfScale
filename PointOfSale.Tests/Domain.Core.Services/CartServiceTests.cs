using Moq;
using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using PointOfSale.Domain.Services.Services;
using System.Collections.Generic;
using Xunit;

namespace PointOfSale.Tests.Domain.Core.Services
{
    public class CartServiceTests
    {
        Mock<ICartRepository> mockCartRepository;

        CartService cartService;

        public CartServiceTests()
        {
            mockCartRepository = new Mock<ICartRepository>();

            cartService = new CartService(mockCartRepository.Object);
        }

        [Fact]
        public void AddItem_NewProductShouldAdd()
        {
            var product = new Product { Code = "A", RetailPrice = 10 };
            var cartLine = new CartLine { Product = product, Quantity = 1 };
            mockCartRepository.Setup(m => m.GetByCode(product.Code)).Returns(cartLine).Verifiable();

            cartService.AddItem(product);

            mockCartRepository.Verify();
            Assert.Equal(2, cartLine.Quantity);
        }

        [Fact]
        public void AddItem_ExistingProductShouldIncrementQuantity()
        {
            var product = new Product { Code = "A", RetailPrice = 10 };
            var cartLine = new CartLine { Product = product, Quantity = 1 };
            mockCartRepository.Setup(m => m.GetByCode(product.Code)).Returns(cartLine).Verifiable();

            cartService.AddItem(product);

            mockCartRepository.Verify();
            Assert.Equal(2, cartLine.Quantity);
        }

        [Fact]
        public void CalculateTotal_NoVolumeProductShouldCalculateRight()
        {
            var expectedPrice = 50m;

            var product = new Product
            {
                Code = "A",
                RetailPrice = 5
            };

            List<CartLine> cartLines = new List<CartLine>
            {
                new CartLine
                {
                    Product = product,
                    Quantity = 10
                }
            };

            mockCartRepository.Setup(m => m.GetAll()).Returns(cartLines).Verifiable();

            var result = cartService.CalculateTotal();

            mockCartRepository.Verify();
            Assert.Equal(expectedPrice, result);
        }

        [Fact]
        public void CalculateTotal_VolumeProductShouldCalculateRight()
        {
            var expectedPrice = 14m;

            var product = new Product
            {
                Code = "B",
                RetailPrice = 5,
                VolumePrice = 3,
                VolumeQuantity = 3
            };

            List<CartLine> cartLines = new List<CartLine>
            {
                new CartLine
                {
                    Product = product,
                    Quantity = 10
                }
            };

            mockCartRepository.Setup(m => m.GetAll()).Returns(cartLines).Verifiable();

            var result = cartService.CalculateTotal();

            mockCartRepository.Verify();
            Assert.Equal(expectedPrice, result);
        }



    }


}
