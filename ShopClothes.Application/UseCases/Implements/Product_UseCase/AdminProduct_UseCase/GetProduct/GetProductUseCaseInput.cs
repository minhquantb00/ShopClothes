using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct
{
    public class GetProductUseCaseInput
    {
        public string? Keyword { get; set; }
        public decimal? PriceForm { get; set; }
        public decimal? PriceTo { get; set; }
        public int? ProductTypeId { get; set; }
    }
}
