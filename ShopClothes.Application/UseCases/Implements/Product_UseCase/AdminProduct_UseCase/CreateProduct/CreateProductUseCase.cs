using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using ShopClothes.Domain.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProduct
{
    public class CreateProductUseCase : IUseCase<CreateProductUseCaseInput, CreateProductUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<User> _userRepository;
        public CreateProductUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Product> productRepository, IRepository<ProductType> productTypeRepository, IRepository<User> userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateProductUseCaseOutput> ExcuteAsync(CreateProductUseCaseInput input)
        {
            CreateProductUseCaseOutput response = new CreateProductUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    response.Errors = new string[] { "Người dùng chưa được xác thực" };
                    return response;
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                }
                var productType = await _productTypeRepository.GetByIdAsync(input.ProductTypeId);
                if(productType == null)
                {
                    response.Errors = new string[] { "Loại sản phẩm không tồn tại" };
                    return response;
                }
                var product = new Product
                {
                    CreateTime = DateTime.Now,
                    Description = input.Description,
                    ErrorQuantity = 0,
                    ImageUrl = await HandleUploadImage.Upfile(input.ImageUrl),
                    InventoryNumber = 0,
                    Price = input.Price,
                    ProductCode = Constant.GenerateCodeActive(),
                    ProductName = input.ProductName,
                    ProductStatus = Domain.Enumerates.ProductStatusEnum.OnSale,
                    ProductTypeId = input.ProductTypeId,
                    ReturnQuantity = 0,
                    SoldeQuantity = 0,
                    AverageRating = 0,
                    PriceAfterDiscount = input.Price
                };

                product = await _productRepository.CreateAsync(product);
                response.Succeeded = true;
                return response;
            }catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                response.Succeeded = false;
                return response;
            }
        }
    }
}
