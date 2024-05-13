using Microsoft.AspNetCore.Http;
using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail
{
    public class CreateProductDetailUseCase : IUseCase<CreateProductDetailUseCaseInput, CreateProductDetailUseCaseOutput>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateProductDetailUseCase(IRepository<Product> productRepository, IRepository<ProductDetail> productDetailRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateProductDetailUseCaseOutput> ExcuteAsync(int? id, CreateProductDetailUseCaseInput input)
        {
            CreateProductDetailUseCaseOutput response = new CreateProductDetailUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                var product = await _productRepository.GetAsync(record => record.Id == id);
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
                if(product == null)
                {
                    response.Errors = new string[] { "Sản phẩm không tồn tại" };
                    return response;
                }
                List<ProductDetail> listDetail = new List<ProductDetail>();
                ProductDetail item = new ProductDetail
                {
                    ColorId = input.ColorId,
                    CreateTime = DateTime.Now,
                    Image = await HandleUploadImage.Upfile(input.Image),
                    ProductDetailStatus = Domain.Enumerates.ProductDetailStatusEnum.Stocking,
                    ProductId = product.Id,
                    ReturnQuantity = 0,
                    InventoryNumber = 0,
                    SizeId = input.SizeId,
                    SoldQuantity = 0
                };
                listDetail.Add(item);
                item = await _productDetailRepository.CreateAsync(item);
                product.ProductDetails = listDetail;
                await _productRepository.UpdateAsync(product);
                response.Succeeded = true;
                return response;

            }catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateProductDetailUseCaseOutput> ExcuteAsync(CreateProductDetailUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
