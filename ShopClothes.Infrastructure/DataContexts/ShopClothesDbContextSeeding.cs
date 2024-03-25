using Microsoft.EntityFrameworkCore;
using ShopClothes.Domain.Constants;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ShopClothes.Infrastructure.DataContexts
{
    public class ShopClothesDbContextSeeding
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
            if (!dbContext.User.Any())
            {
                var user = new User
                {
                    UserName = "admin",
                    Password = BcryptNet.HashPassword("Abc@123"),
                    AvatarUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5zThKtjx7rImritWaiC62PPk65OYt70P7qA&usqp=CAU",
                    Email = "admin@gmail.com",
                    CreateTime = DateTime.Now,
                    PhoneNumber = "0987654321",
                    Gender = Domain.Enumerates.GenderEnum.Male,
                    UserStatus = Domain.Enumerates.UserStatusEnum.Activated,
                };
                await dbContext.User.AddAsync(user);
                 dbContext.SaveChanges();
            }
            if(!dbContext.Role.Any(x => x.RoleName.Equals(RoleConstant.Admin)))
            {
                await dbContext.AddAsync(new Role { RoleCode = "Admin", RoleName = RoleConstant.Admin });
                dbContext.SaveChanges();
            }
            if (!dbContext.Role.Any(x => x.RoleName.Equals(RoleConstant.Seller)))
            {
                await dbContext.AddAsync(new Role { RoleCode = "Seller", RoleName = RoleConstant.Seller });
                dbContext.SaveChanges();
            }
            if (!dbContext.Role.Any(x => x.RoleName.Equals(RoleConstant.User)))
            {
                await dbContext.AddAsync(new Role { RoleCode = "User", RoleName = RoleConstant.User });
                dbContext.SaveChanges();
            }
            if (!dbContext.UserRole.Any())
            {
                var defaultUser = await dbContext.User.FirstOrDefaultAsync(x => x.UserName == "admin");
                dbContext.SaveChanges();
            }
        }
    }
}
