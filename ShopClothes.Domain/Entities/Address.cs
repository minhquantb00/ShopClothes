using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string ConsigneeName { get; set; }
        public string WardId { get; set; }
        public string DistrictId { get; set; }
        public string ProvinceId { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string AddressDetail { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMainAddress { get; set; }

        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
