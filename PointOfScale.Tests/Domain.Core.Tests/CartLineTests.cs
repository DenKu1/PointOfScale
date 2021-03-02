using PointOfScale.Domain.Core.Entities;
using Xunit;

namespace PointOfScale.Tests.Domain.Core.Tests
{
    public class CartLineTests
    {
        [Fact]
        public void CalculatePrice_NoVolumeProductShouldCalculateRight()
        {
            var product = new Product
            { 
                Code = "A",
                RetailPrice = 5
            };

            CartLine cartLine = new CartLine 
            { Product = product,
                Quantity = 10
            };

            var result = cartLine.CalculatePrice();

            Assert.Equal(50, result);
        }

        [Fact]
        public void CalculatePrice_VolumeProductShouldCalculateRight()
        {
            var product = new Product
            { 
                Code = "B",
                RetailPrice = 5,
                VolumePrice = 3,
                VolumeQuantity = 3 
            };

            CartLine cartLine = new CartLine 
            { 
                Product = product, 
                Quantity = 10 
            };

            var result = cartLine.CalculatePrice();

            Assert.Equal(14, result);
        }
    }
}
