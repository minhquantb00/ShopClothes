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
        private readonly IRepository<Color> _colorRepository;
        private readonly IRepository<Size> _sizeRepository;
        public GetProductUseCaseMappingProduct(IRepository<ProductType> productTypeRepository, IRepository<ProductImage> productImageRepository, IRepository<ProductDetail> productDetailRepository, IRepository<Color> colorRepository, IRepository<Size> sizeRepository)
        {
            _productTypeRepository = productTypeRepository;
            _productImageRepository = productImageRepository;
            _productDetailRepository = productDetailRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
        }
        public DataResponseProduct EntityToDTO(Product product)
        {
            return new DataResponseProduct
            {
                Id = product.Id,
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
                ProductDetails = _productDetailRepository.GetAllAsync(record => record.ProductId == product.Id).Result.Select(item => new DataResponseProductDetail
                {
                    ColorName = _colorRepository.GetByIdAsync(item.ColorId).Result.ColorName,
                    CreateTime = item.CreateTime,
                    Image = item.Image,
                    InventoryNumber = item.InventoryNumber,
                    ProductDetailStatus = item.ProductDetailStatus.ToString(),
                    ReturnQuantity = item.ReturnQuantity,
                    SizeName = _sizeRepository.GetByIdAsync(item.SizeId).Result.SizeName,
                    SoldQuantity = item.SoldQuantity,
                    UpdateTime = item.UpdateTime
                }).AsQueryable(),
                ProductImages = _productImageRepository.GetAllAsync(record => record.ProductId == product.Id).Result.Select(item => new DataResponseProductImage
                {
                    ImageUrl = item.ImageUrl
                }).AsQueryable(),
            };
        }
    }
}
