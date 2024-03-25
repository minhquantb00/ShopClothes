using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class ShippingMethod : BaseEntity
    {
        public string ShippingMethodName { get; set; }
        public ShippingMethodStatusEnum? ShippingMethodStatus { get; set; } = ShippingMethodStatusEnum.Active;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
