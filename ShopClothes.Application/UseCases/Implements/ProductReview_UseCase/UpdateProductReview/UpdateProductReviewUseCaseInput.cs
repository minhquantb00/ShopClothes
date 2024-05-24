using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.UpdateProductReview
{
    public class UpdateProductReviewUseCaseInput
    {
        public int ProductReviewId { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
    }
}
