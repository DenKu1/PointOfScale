using Moq;
using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Services;
using PointOfSale.Models;
using PointOfSale.Presentation.Concrete;
using PointOfSale.Presentation.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSale.Tests.Presentation.Concrete
{
    public class PointOfSaleTerminalTests
    {
        Mock<ICartService> mockCartService;

        Mock<IProductRangeService> mockProductRangeService;

        PointOfSaleTerminal terminal;

        public PointOfSaleTerminalTests()
        {
            mockCartService = new Mock<ICartService>();

            mockProductRangeService = new Mock<IProductRangeService>();

            terminal = new PointOfSaleTerminal(
                mockCartService.Object, mockProductRangeService.Object);
        }

        [Fact]
        public void Scan_NullProductCodeShouldRaiseException()
        {
            string productCode = null;

            Action act = () => terminal.Scan(productCode);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(nameof(productCode), exception.ParamName);
        }

        [Fact]
        public void Scan_UnexistingProductCodeShouldRaiseException()
        {
            string productCode = "E";
            mockProductRangeService.Setup(m => m.GetByCode(productCode)).Returns<Product>(null).Verifiable();

            Action act = () => terminal.Scan(productCode);

            PointOfSaleException exception = Assert.Throws<PointOfSaleException>(act);
            Assert.Equal($"Unexisting product code: {productCode}", exception.Message);
            mockProductRangeService.Verify();
        }

        [Fact]
        public void Scan_ShouldCallAddItem()
        {
            string productCode = "A";
            var product = new Product { Code = productCode };

            mockProductRangeService.Setup(m => m.GetByCode(productCode)).Returns(product).Verifiable();
            mockCartService.Setup(m => m.AddItem(product)).Verifiable();

            terminal.Scan(productCode);

            mockCartService.Verify();
        }

        [Fact]
        public void SetPricing_NullProductCodeShouldRaiseException()
        {
            List<ProductModel> productModels = null;

            Action act = () => terminal.SetPricing(productModels);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(nameof(productModels), exception.ParamName);
        }

        [Fact]
        public void SetPricing_NotUniqueProducCodesShouldRaiseException()
        {
            List<ProductModel> dublicateProducts = new List<ProductModel>
            {
                new ProductModel { Code = "A"},
                new ProductModel { Code = "A"}
            };

            Action act = () => terminal.SetPricing(dublicateProducts);

            PointOfSaleException exception = Assert.Throws<PointOfSaleException>(act);
            Assert.Equal("Product codes are not unique", exception.Message);
        }

        [Fact]
        public void Scan_ShouldCallLoadProducts()
        {
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel { Code = "A"},
                new ProductModel { Code = "B"}
            };

            mockProductRangeService.Setup(m => m.LoadProducts(products)).Verifiable();

            terminal.SetPricing(products);

            mockProductRangeService.Verify();
        }

        [Fact]
        public void CalculateTotal_ShouldCallCalculateTotal()
        {
            mockCartService.Setup(m => m.CalculateTotal()).Verifiable();

            terminal.CalculateTotal();

            mockCartService.Verify();
        }
    }
}
