using ShopClothes.Domain.Entities;
using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct
{
    public class DataResponseProductDetail
    {
        public int InventoryNumber { get; set; }
        public int SoldQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public string ProductDetailStatus { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
    }
}
