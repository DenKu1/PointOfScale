using Moq;
using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using PointOfScale.DTOs;
using PointOfScale.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PointOfScale.Tests.Infrastructure.Services.Tests
{
    public class ProductRangeServiceTests
    {
        Mock<IProductRangeRepository> mockProductRangeRepository;

        ProductRangeService productRangeService;

        public ProductRangeServiceTests()
        {
            mockProductRangeRepository = new Mock<IProductRangeRepository>();

            productRangeService = new ProductRangeService(mockProductRangeRepository.Object);
        }

        [Fact]
        public void GetByCode_ShouldReturnProductFromRepository()
        {
            var product = new Product { Code = "A", RetailPrice = 10 };
            mockProductRangeRepository.Setup(m => m.GetByCode(product.Code)).Returns(product).Verifiable();

            var result = productRangeService.GetByCode("A");

            mockProductRangeRepository.Verify();
            Assert.Equal(product, result);
        }

        [Fact]
        public void LoadProducts_ShouldCallLoadFromRepository()
        {
            IEnumerable<Product> result = null;
            var productDTOs = new List<ProductDTO> { new ProductDTO { Code = "A", RetailPrice = 10 } };

            mockProductRangeRepository.Setup(
                m => m.LoadProducts(It.IsAny<IEnumerable<Product>>())).Callback((IEnumerable<Product> p) => result = p).Verifiable();

            productRangeService.LoadProducts(productDTOs);

            mockProductRangeRepository.Verify();

            Assert.NotNull(result.ToList().FirstOrDefault(p => p.Code == "A"));
        }
    }
}

