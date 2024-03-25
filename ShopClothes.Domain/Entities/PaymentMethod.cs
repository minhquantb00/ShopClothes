using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string PaymentMethodName { get; set; }
        public PaymentMethodStatusEnum PaymentMethodStatus { get; set; } = PaymentMethodStatusEnum.Active;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
