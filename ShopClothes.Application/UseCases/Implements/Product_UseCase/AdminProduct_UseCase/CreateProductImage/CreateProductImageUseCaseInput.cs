using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductImage
{
    public class CreateProductImageUseCaseInput
    {
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
