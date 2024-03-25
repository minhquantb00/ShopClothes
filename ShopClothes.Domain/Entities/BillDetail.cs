using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class BillDetail : BaseEntity
    {
        public int BillId { get; set; }
        public virtual Bill? Bill { get; set; }
        public int ProductDetailId { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Note { get; set; }
        public int? WaitingQuantity { get; set; } = 0;
        public int? ReturnQuantity { get; set; } = 0;
        public int? ErrorQuantity { get; set; } = 0;
        public BillDetailStatusEnum? BillDetailStatus { get; set; } = BillDetailStatusEnum.NotYetReturned;
    }
}
