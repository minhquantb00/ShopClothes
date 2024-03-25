using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SoldeQuantity { get; set; } = 0;
        public string ImageUrl { get; set; }
        public int ReturnQuantity { get; set; } = 0;  
        public double PriceAfterDiscount { get; set; }
        public DateTime CreateTime { get; set; }
        public int ErrorQuantity { get; set; } = 0;
        public double? AverageRating { get; set; }
        public DateTime? UpdateTime { get; set; }
        public ProductStatusEnum? ProductStatus { get; set; } = ProductStatusEnum.OnSale;
        public int InventoryNumber { get; set; } = 0;
        public int ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<EventProduct>? EventProducts { get; set; }
        public virtual ICollection<ProductImage>? ProductImages { get; set; }
        public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
    }
}
