
using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class UserVoucher : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public DateTime ExpiryTime { get; set; }
        public double DiscountPercent { get; set; }
        public UserVoucherStatusEnum? UserVoucherStatus { get; set; } = UserVoucherStatusEnum.UnUsed;
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
