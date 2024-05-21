using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.GetProductById
{
    public class GetProductByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseProduct DataResponseProduct { get; set; }
    }
}
