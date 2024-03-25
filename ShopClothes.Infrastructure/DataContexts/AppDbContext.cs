using Microsoft.EntityFrameworkCore;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Infrastructure.DataContexts
{
    public class AppDbContext :  DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillDetail> BillDetail { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<DiscountEvent> DiscountEvent { get; set; }
        public virtual DbSet<EventProduct> EventProduct { get; set; }
        public virtual DbSet<FavoriteProduct> FavoriteProduct { get; set;}
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<RankCustomer> RankCustomer { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserVoucher> UserVoucher { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
