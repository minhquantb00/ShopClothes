using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.CreateProductReview
{
    public class CreateProductReviewUseCaseInput
    {
        [Required(ErrorMessage = "ProductDetailId is required")]
        public int ProductDetailId { get; set; }
        [Required(ErrorMessage = "ProductDetailId is required")]
        public string? Content { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? ImageUrl { get; set; }
        [Required(ErrorMessage = "NumberOfStars is required")]
        public int NumberOfStars { get; set; }
    }
}
