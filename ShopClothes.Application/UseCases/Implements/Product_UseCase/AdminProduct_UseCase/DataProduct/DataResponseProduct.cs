using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.DataProduct
{
    public class DataResponseProduct
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SoldeQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int ReturnQuantity { get; set; }
        public double PriceAfterDiscount { get; set; }
        public DateTime CreateTime { get; set; }
        public int ErrorQuantity { get; set; }
        public double? AverageRating { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string ProductStatus { get; set; }
        public int InventoryNumber { get; set; }
        public string ProductTypeName { get; set; }
        public IQueryable<DataResponseProductImage>? ProductImages { get; set; }
        public IQueryable<DataResponseProductDetail>? ProductDetails { get; set; }
    }
}
