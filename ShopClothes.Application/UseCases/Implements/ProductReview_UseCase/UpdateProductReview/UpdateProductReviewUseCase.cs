using Microsoft.AspNetCore.Http;
using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.UpdateProductReview
{
    public class UpdateProductReviewUseCase : IUseCase<UpdateProductReviewUseCaseInput, UpdateProductReviewUseCaseOutput>
    {
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateProductReviewUseCase(IRepository<ProductReview> productReviewRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productReviewRepository = productReviewRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdateProductReviewUseCaseOutput> ExcuteAsync(UpdateProductReviewUseCaseInput input)
        {
            UpdateProductReviewUseCaseOutput response = new UpdateProductReviewUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                var productReview = await _productReviewRepository.GetAsync(record => record.Id == input.ProductReviewId);
                if(productReview == null)
                {
                    response.Errors = new string[] { "Product review không tồn tại" };
                    return response;
                }
                var userId = currentUser.FindFirst("Id").Value;
                if(productReview.UserId != int.Parse(userId))
                {
                    response.Errors = new string[] { "Bạn không phải là người review sản phẩm này" };
                    return response;
                }
                productReview.NumberOfStars = input.NumberOfStars;
                productReview.Content = input.Content;
                productReview.ImageUrl = await HandleUploadImage.Upfile(input.ImageUrl);
                await _productReviewRepository.UpdateAsync(productReview);
                response.Succeeded = true;
                return response;
            }catch(Exception ex)
            {
                response.Succeeded = false;
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<UpdateProductReviewUseCaseOutput> ExcuteAsync(int? id, UpdateProductReviewUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
