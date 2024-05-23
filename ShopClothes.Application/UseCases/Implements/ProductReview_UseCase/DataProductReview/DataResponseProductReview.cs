using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.DataProductReview
{
    public class DataResponseProductReview
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime ReviewTime { get; set; }
    }
}
