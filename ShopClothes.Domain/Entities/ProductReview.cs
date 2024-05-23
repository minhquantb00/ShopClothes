using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int ProductDetailId { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime ReviewTime { get; set; }
    }
}
