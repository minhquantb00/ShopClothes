using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.CreateProductType
{
    public class CreateProductTypeUseCaseInput
    {
        [Required(ErrorMessage = "ProductTypeName is required")]
        public string ProductTypeName { get; set; }
    }
}
