using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; } // người mua
        public virtual User? User { get; set; }
        public int ProductDetailId { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
