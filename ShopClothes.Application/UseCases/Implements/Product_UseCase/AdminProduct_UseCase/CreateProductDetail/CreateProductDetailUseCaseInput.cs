using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail
{
    public class CreateProductDetailUseCaseInput
    {
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
    }
}
