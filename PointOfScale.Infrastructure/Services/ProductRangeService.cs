using PointOfScale.Domain.Core.Entities;
using PointOfScale.Domain.Interfaces.Repositories;
using PointOfScale.Domain.Interfaces.Services;
using PointOfScale.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PointOfScale.Infrastructure.Services
{
    public class ProductRangeService : IProductRangeService
    {
        private readonly IProductRangeRepository _repo;

        public ProductRangeService(IProductRangeRepository repository)
        {
            _repo = repository;
        }

        public Product GetByCode(string productCode)
        {
            return _repo.GetByCode(productCode);
        }

        public void LoadProducts(IEnumerable<ProductDTO> productDTOs)
        {
            var products = productDTOs.Select(dto => new Product
            {
                Code = dto.Code,
                RetailPrice = dto.RetailPrice,
                VolumePrice = dto.VolumePrice,
                VolumeQuantity = dto.VolumeQuantity
            });

            _repo.LoadProducts(products);
        }
    }
}
