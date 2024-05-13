using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct
{
    public class GetProductUseCaseMappingProduct
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<ProductImage> _productImageRepository;
        private readonly IRepository<ProductDetail> _productDetailRepository;
        public GetProductUseCaseMappingProduct(IRepository<ProductType> productTypeRepository, IRepository<ProductImage> productImageRepository, IRepository<ProductDetail> productDetailRepository)
        {
            _productTypeRepository = productTypeRepository;
            _productImageRepository = productImageRepository;
            _productDetailRepository = productDetailRepository;
        }
        public DataResponseProduct EntityToDTO(Product product)
        {
            return new DataResponseProduct
            {
                AverageRating = product.AverageRating,
                PriceAfterDiscount = product.PriceAfterDiscount,
                CreateTime = product.CreateTime,
                Description = product.Description,
                ErrorQuantity = product.ErrorQuantity,
                ImageUrl = product.ImageUrl,
                InventoryNumber = product.InventoryNumber,
                Price = product.Price,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductStatus = product.ProductStatus.ToString(),
                ProductTypeName = _productTypeRepository.GetByIdAsync(product.ProductTypeId).Result.ProductTypeName,
                ReturnQuantity = product.ReturnQuantity,
                SoldeQuantity = product.SoldeQuantity,
                UpdateTime = product.UpdateTime,
            };
        }
    }
}
