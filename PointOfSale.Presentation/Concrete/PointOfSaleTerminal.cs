using PointOfSale.Domain.Interfaces.Services;
using PointOfSale.Models;
using PointOfSale.Presentation.Abstract;
using PointOfSale.Presentation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Presentation.Concrete
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly ICartService _cartService;
        private readonly IProductRangeService _productRangeService;

        public PointOfSaleTerminal(ICartService cartService, IProductRangeService productRangeService)
        {
            _cartService = cartService;
            _productRangeService = productRangeService;
        }

        public void Scan(string productCode)
        {
            if (productCode is null)
            {
                throw new ArgumentNullException(nameof(productCode));
            }

            var product = _productRangeService.GetByCode(productCode);

            if (product == null)
            {
                throw new PointOfSaleException($"Unexisting product code: {productCode}");
            }

            _cartService.AddItem(product);
        }

        public void SetPricing(IEnumerable<ProductModel> productModels)
        {
            if (productModels is null)
            {
                throw new ArgumentNullException(nameof(productModels));
            }

            if (productModels.Select(p => p.Code).Distinct().Count() != productModels.Count())
            {
                throw new PointOfSaleException("Product codes are not unique");
            }

            _productRangeService.LoadProducts(productModels);
        }

        public decimal CalculateTotal()
        {
            return _cartService.CalculateTotal();
        }
    }
}
