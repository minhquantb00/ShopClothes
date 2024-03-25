using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class RankCustomer : BaseEntity
    {
        public string RankCode { get; set; }
        public string RankName { get; set;}
        public double DiscountPercent { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
