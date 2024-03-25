using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class DiscountEvent : BaseEntity
    {
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string EventLogo {  get; set; }
        public double DiscountPercent { get; set; }
        public DiscountEventEnum? DiscountEventStatus { get; set; } = DiscountEventEnum.NotYetActive;
        public virtual ICollection<EventProduct>? EventProducts { get; set; }
    }
}
