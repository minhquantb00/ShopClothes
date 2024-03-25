using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class EventProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int DiscountEventId { get; set; }
        public virtual DiscountEvent? DiscountEvent { get; set; }
    }
}
