using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
