using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public GenderEnum Gender { get; set; } = GenderEnum.Unknown;
        public int? Point { get; set; } = 0;
        public UserStatusEnum UserStatus { get; set; } = UserStatusEnum.UnActivated;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? RankCustomerId { get; set; }
        public virtual RankCustomer? RankCustomer { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<ProductReview>? ProductReviews { get; set; }
        public virtual ICollection<Address>? Address { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
        public virtual ICollection<UserVoucher>? UserVouchers { get; set; }
        public virtual ICollection<FavoriteProduct>? FavoriteProducts { get; set; } 
    }
}
