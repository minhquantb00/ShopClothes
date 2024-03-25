using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Voucher : BaseEntity
    {
        public string VoucherCode { get; set; }
        public string VoucherName { get; set;}
        public double DiscountPercent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public VoucherEnum? VoucherStatus { get; set; } = VoucherEnum.DiscontinuedRelease;
        public virtual ICollection<UserVoucher>? UserVouchers { get; set; }
    }
}
