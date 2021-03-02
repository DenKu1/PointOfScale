using Moq;
using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using PointOfScale.Infrastructure.Services;
using Xunit;

namespace PointOfScale.Tests.Infrastructure.Services.Tests
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
            var cartLine = new CartLine { Product = product, Quantity = 1};
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
        public void CalculateTotal_ShouldReturnRightSum()
        {
            var expected = 10m;
            mockCartRepository.Setup(m => m.SumPrice()).Returns(expected).Verifiable();

            var result = cartService.CalculateTotal();

            mockCartRepository.Verify();
            Assert.Equal(expected, result);
        }
    }


}
