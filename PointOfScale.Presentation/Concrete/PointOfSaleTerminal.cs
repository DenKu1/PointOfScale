using PointOfScale.Domain.Interfaces.Services;
using PointOfScale.DTOs;
using PointOfScale.Presentation.Abstract;
using PointOfScale.Presentation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfScale.Presentation.Concrete
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
                throw new PointOfScaleException($"Unexisting product code: {productCode}");
            }

            _cartService.AddItem(product);
        }

        public void SetPricing(IEnumerable<ProductDTO> productDTOs)
        {
            if (productDTOs is null)
            {
                throw new ArgumentNullException(nameof(productDTOs));
            }

            if (productDTOs.Select(p => p.Code).Distinct().Count() != productDTOs.Count())
            {
                throw new PointOfScaleException("Product codes are not unique");
            }

            _productRangeService.LoadProducts(productDTOs);
        }

        public decimal CalculateTotal()
        {
            return _cartService.CalculateTotal();
        }
    }
}
