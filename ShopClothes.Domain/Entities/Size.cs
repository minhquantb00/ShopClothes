using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Size : BaseEntity
    {
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
    }
}
