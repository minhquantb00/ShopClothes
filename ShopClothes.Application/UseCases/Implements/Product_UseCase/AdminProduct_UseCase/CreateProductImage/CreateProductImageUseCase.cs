using Microsoft.AspNetCore.Http;
using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductImage
{
    public class CreateProductImageUseCase : IUseCase<CreateProductImageUseCaseInput, CreateProductImageUseCaseOutput>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductImage> _productImageRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateProductImageUseCase(IRepository<Product> productRepository, IRepository<ProductImage> productImageRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateProductImageUseCaseOutput> ExcuteAsync(int? id, CreateProductImageUseCaseInput input)
        {
            CreateProductImageUseCaseOutput response = new CreateProductImageUseCaseOutput
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
                    return response;
                }
                var product = await _productRepository.GetAsync(record => record.Id == id);
                if (product == null)
                {
                    response.Errors = new string[] { "Sản phẩm không tồn tại" };
                    return response;
                }
                List<ProductImage> listDetail = new List<ProductImage>();
                ProductImage item = new ProductImage
                {
                    ImageUrl = await HandleUploadImage.Upfile(input.File),
                    ProductId = product.Id
                };
                listDetail.Add(item);
                item = await _productImageRepository.CreateAsync(item);
                product.ProductImages = listDetail;
                await _productRepository.UpdateAsync(product);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateProductImageUseCaseOutput> ExcuteAsync(CreateProductImageUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
