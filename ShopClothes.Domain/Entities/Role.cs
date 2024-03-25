using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
