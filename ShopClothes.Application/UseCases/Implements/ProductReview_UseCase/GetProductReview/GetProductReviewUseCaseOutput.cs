﻿using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.DataProductReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.GetProductReview
{
    public class GetProductReviewUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseProductReview> ProductReviews { get; set; }
    }
}
