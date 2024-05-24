using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.UpdateProductType
{
    public class UpdateProductTypeUseCaseInput
    {
        [Required(ErrorMessage = "ProductTypeId is required")]
        public int ProductTypeId { get; set; }

        public string? ProductTypeName { get; set; }
    }
}
