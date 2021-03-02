using PointOfScale.Domain.Core.Entities;
using PointOfScale.Infrastructure.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PointOfScale.Tests.Infrastructure.DataAccess.Tests
{
    public class ProductRangeRepositoryTests
    {
        PointOfScaleContainer container;

        ProductRangeRepository productRangeRepository;

        public ProductRangeRepositoryTests()
        {
            container = new PointOfScaleContainer();

            productRangeRepository = new ProductRangeRepository(container);

            container.Products = new List<Product>
            {
                new Product { Code = "A", RetailPrice = 1.25m, VolumePrice = 3m, VolumeQuantity = 3 },
                new Product { Code = "B", RetailPrice = 4.25m },
                new Product { Code = "C", RetailPrice = 1m, VolumePrice = 5m, VolumeQuantity = 6 },
                new Product { Code = "D", RetailPrice = 0.75m}
            };
        }

        [Fact]
        public void LoadProducts_ShouldSetNewList()
        {
            var products = new List<Product>();

            productRangeRepository.LoadProducts(products);

            Assert.Equal(products, container.Products);
        }

        [Fact]
        public void GetByCode_ShouldGetRightProduct()
        {
            string productCode = "B";
            var expected = container.Products.First(p => p.Code == productCode);

            var result = productRangeRepository.GetByCode(productCode);

            Assert.Equal(expected, result);
        }



    }
}
