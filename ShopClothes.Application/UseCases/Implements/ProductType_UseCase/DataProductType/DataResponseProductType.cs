using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.DataProductType
{
    public class DataResponseProductType
    {
        public string ProductTypeName { get; set; }
        public IQueryable<DataResponseProduct> DataResponseProducts { get; set; }
    }
}
