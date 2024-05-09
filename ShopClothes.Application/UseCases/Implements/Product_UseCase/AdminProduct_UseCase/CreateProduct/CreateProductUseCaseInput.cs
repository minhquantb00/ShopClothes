using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProduct
{
    public class CreateProductUseCaseInput
    {
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "ImageUrl is required")]
        [DataType(DataType.Upload)]
        public IFormFile ImageUrl { get; set; }
        [Required(ErrorMessage = "ProductType is required")]
        public int ProductTypeId { get; set; }
    }
}
