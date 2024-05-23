using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.MappingProductReview;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.GetProductReview
{
    public class GetProductReviewUseCase : IUseCase<GetProductReviewUseCaseInput, GetProductReviewUseCaseOutput>
    {
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly ProductReviewConverter _productReviewConverter;
        public GetProductReviewUseCase(IRepository<ProductReview> productReviewRepository, ProductReviewConverter productReviewConverter)
        {
            _productReviewRepository = productReviewRepository;
            _productReviewConverter = productReviewConverter;
        }
        public async Task<GetProductReviewUseCaseOutput> ExcuteAsync(GetProductReviewUseCaseInput input)
        {
            var listProductReview = await _productReviewRepository.GetAllAsync();
            GetProductReviewUseCaseOutput response = new GetProductReviewUseCaseOutput
            {
                Succeeded = true,
                ProductReviews = listProductReview.Select(x => _productReviewConverter.EntityToDTO(x))
            };
            return response;
        }

        public async Task<GetProductReviewUseCaseOutput> ExcuteAsync(int? id, GetProductReviewUseCaseInput input)
        {
            var productReview = await _productReviewRepository.GetAllAsync(x => x.Id == id);
            GetProductReviewUseCaseOutput response = new GetProductReviewUseCaseOutput
            {
                Succeeded = true,
                ProductReviews = productReview.Select(x => _productReviewConverter.EntityToDTO(x))
            };
            return response;
        }
    }
}
