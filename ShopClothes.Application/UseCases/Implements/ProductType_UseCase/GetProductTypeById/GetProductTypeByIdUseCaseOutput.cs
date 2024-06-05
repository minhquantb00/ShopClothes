using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct;
using ShopClothes.Application.UseCases.Implements.ProductType_UseCase.DataProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.GetProductTypeById
{
    public class GetProductTypeByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseProductType DataResponseProductType { get; set; }
    }
}
