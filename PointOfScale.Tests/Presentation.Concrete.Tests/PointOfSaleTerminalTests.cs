using Moq;
using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Services;
using PointOfScale.DTOs;
using PointOfScale.Presentation.Concrete;
using PointOfScale.Presentation.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfScale.Tests.Presentation.Concrete.Tests
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

            PointOfScaleException exception = Assert.Throws<PointOfScaleException>(act);
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
            List<ProductDTO> productDTOs = null;

            Action act = () => terminal.SetPricing(productDTOs);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(nameof(productDTOs), exception.ParamName);
        }

        [Fact]
        public void SetPricing_NotUniqueProducCodesShouldRaiseException()
        {
            List<ProductDTO> dublicateProducts = new List<ProductDTO>
            { 
                new ProductDTO { Code = "A"},
                new ProductDTO { Code = "A"}
            };

            Action act = () => terminal.SetPricing(dublicateProducts);

            PointOfScaleException exception = Assert.Throws<PointOfScaleException>(act);
            Assert.Equal("Product codes are not unique", exception.Message);
        }

        [Fact]
        public void Scan_ShouldCallLoadProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>
            {
                new ProductDTO { Code = "A"},
                new ProductDTO { Code = "B"}
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
