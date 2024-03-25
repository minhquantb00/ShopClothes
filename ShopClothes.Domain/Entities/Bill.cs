using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public int UserId { get; set; } // người mua
        public virtual User? User { get; set; }
        public int AddressId { get; set; }
        public string TradingCode { get; set; }
        public int ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? PaymentTime { get; set; }
        public double? TotalPriceBeforeDiscount { get; set; }
        public BillStatusEnum? BillStatus { get; set; } = BillStatusEnum.WaitConfirmation;
        public string Note { get; set; }
        public string? ReasonForRefusal { get; set; }
        public double TotalPriceAfterDiscount { get; set; }
        public int? UserVoucherId { get; set; } // Voucher giảm cho người dùng đó
        public virtual UserVoucher? UserVoucher { get; set; }
        public int EmployeeCreateBillId { get; set; }
        public double ShippingFee { get; set; }
        public virtual ICollection<BillDetail>? BillDetails { get; set; }
        public virtual ICollection<ProductReview>? ProductReviews { get; set; }
    }
}
