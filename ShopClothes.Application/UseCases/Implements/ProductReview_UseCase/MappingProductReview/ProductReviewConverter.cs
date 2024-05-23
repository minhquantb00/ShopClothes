using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.DataProductReview;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.MappingProductReview
{
    public class ProductReviewConverter
    {
        public DataResponseProductReview EntityToDTO(ProductReview entity)
        {
            return new DataResponseProductReview
            {
                Content = entity.Content,
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                NumberOfStars = entity.NumberOfStars,
                ReviewTime = entity.ReviewTime,
            };
        }
    }
}
