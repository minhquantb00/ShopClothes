using Microsoft.AspNetCore.Http;
using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.CreateProductReview
{
    public class CreateProductReviewUseCase : IUseCase<CreateProductReviewUseCaseInput, CreateProductReviewUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<ProductDetail> _productRepository;
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Bill> _billRepository;
        public CreateProductReviewUseCase(IHttpContextAccessor httpContextAccessor, IRepository<ProductDetail> productRepository, IRepository<ProductReview> productReviewRepository, IRepository<User> userRepository, IRepository<Bill> billRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
            _userRepository = userRepository;
            _billRepository = billRepository;
        }

        public async Task<CreateProductReviewUseCaseOutput> ExcuteAsync(CreateProductReviewUseCaseInput input)
        {
            CreateProductReviewUseCaseOutput response = new CreateProductReviewUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                var userId = currentUser.FindFirst("Id").Value;
                var user = await _userRepository.GetAsync(record => record.Id == int.Parse(userId));
                var listBill = await _billRepository.GetAllAsync(record => record.UserId == user.Id);
                if(listBill.ToList().Count <= 0)
                {
                    response.Succeeded = false;
                    response.Errors = new string[] { "Bạn chưa mua hàng nên không thể đánh giá" };
                    return response;
                }
                var productDetail = await _productRepository.GetAsync(record => record.Id == input.ProductDetailId);
                if(productDetail == null)
                {
                    response.Succeeded = false;
                    response.Errors = new string[] { "Sản phẩm không tồn tại" };
                    return response;
                }
                ProductReview item = new ProductReview
                {
                    Content = input.Content,
                    ImageUrl = await HandleUploadImage.Upfile(input.ImageUrl),
                    NumberOfStars = input.NumberOfStars,
                    ProductDetailId = input.ProductDetailId,
                    ReviewTime = DateTime.Now,
                    UserId = user.Id,
                };

                item = await _productReviewRepository.CreateAsync(item);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                response.Succeeded = false;
                return response;
            }
        }

        public Task<CreateProductReviewUseCaseOutput> ExcuteAsync(int? id, CreateProductReviewUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
