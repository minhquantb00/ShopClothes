using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Color : BaseEntity
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
    }
}
