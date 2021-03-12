using Moq;
using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using PointOfSale.Domain.Services.Services;
using PointOfSale.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PointOfSale.Tests.Domain.Core.Services
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
            var productModels = new List<ProductModel> { new ProductModel { Code = "A", RetailPrice = 10 } };

            mockProductRangeRepository.Setup(
                m => m.LoadProducts(It.IsAny<IEnumerable<Product>>())).Callback((IEnumerable<Product> p) => result = p).Verifiable();

            productRangeService.LoadProducts(productModels);

            mockProductRangeRepository.Verify();

            Assert.NotNull(result.ToList().FirstOrDefault(p => p.Code == "A"));
        }
    }
}

