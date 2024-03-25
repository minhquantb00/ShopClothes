using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class ProductDetail : BaseEntity
    {
        public int InventoryNumber {  get; set; }
        public int SoldQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public ProductDetailStatusEnum? ProductDetailStatus { get; set; } = ProductDetailStatusEnum.Stocking;
        public string Image {  get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int ColorId { get; set; }
        public virtual Color? Color { get; set; }
        public int SizeId { get; set; }
        public virtual Size? Size { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }   
        public virtual ICollection<BillDetail>? BillDetails { get; set; }
        public virtual ICollection<FavoriteProduct>? FavoriteProducts { get; set;}
        public virtual ICollection<Cart>? Carts { get; set; }
        public virtual ICollection<ProductReview>? ProductReviews { get; set; }
    }
}
