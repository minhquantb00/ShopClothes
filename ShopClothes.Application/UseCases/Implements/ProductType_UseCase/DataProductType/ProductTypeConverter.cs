using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.DataProductType
{
    public class ProductTypeConverter
    {
        private readonly IRepository<Product> _repository;
        private readonly GetProductUseCaseMappingProduct _mappingProduct;
        public ProductTypeConverter(IRepository<Product> repository, GetProductUseCaseMappingProduct mappingProduct)
        {
            _repository = repository;
            _mappingProduct = mappingProduct;
        }
        public DataResponseProductType EntityToDTO(ProductType entityType)
        {
            return new DataResponseProductType
            {
                ProductTypeName = entityType.ProductTypeName,
                DataResponseProducts = _repository.GetAllAsync(item => item.ProductTypeId == entityType.Id).Result.Select(item => _mappingProduct.EntityToDTO(item))
            };
        }
    }
}
