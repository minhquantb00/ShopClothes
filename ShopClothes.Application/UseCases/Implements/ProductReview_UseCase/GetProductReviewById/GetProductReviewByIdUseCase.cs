using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.MappingProductReview;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.GetProductReviewById
{
    public class GetProductReviewByIdUseCase : IUseCaseGetById<int, GetProductReviewByIdUseCaseOutput>
    {
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly ProductReviewConverter _productReviewConverter;
        public GetProductReviewByIdUseCase(IRepository<ProductReview> productReviewRepository, ProductReviewConverter productReviewConverter)
        {
            _productReviewRepository = productReviewRepository;
            _productReviewConverter = productReviewConverter;
        }

        public async Task<GetProductReviewByIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetProductReviewByIdUseCaseOutput response = new GetProductReviewByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var result = await _productReviewRepository.GetAsync(record => record.Id == id);
            if(result == null)
            {
                response.Succeeded = false;
                response.Errors = new string[] { "Không tìm thấy product review" };
                return response;
            }
            response.DataResponseProductReview = _productReviewConverter.EntityToDTO(result);
            response.Succeeded = true;
            return response;
        }
    }
}
