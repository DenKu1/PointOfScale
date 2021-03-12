using PointOfSale.Domain.Core.Entities;
using PointOfSale.Domain.Interfaces.Repositories;
using PointOfSale.Domain.Interfaces.Services;
using PointOfSale.Models;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain.Services.Services
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

        public void LoadProducts(IEnumerable<ProductModel> productModels)
        {
            var products = productModels.Select(model => new Product
            {
                Code = model.Code,
                RetailPrice = model.RetailPrice,
                VolumePrice = model.VolumePrice,
                VolumeQuantity = model.VolumeQuantity
            });

            _repo.LoadProducts(products);
        }
    }
}
