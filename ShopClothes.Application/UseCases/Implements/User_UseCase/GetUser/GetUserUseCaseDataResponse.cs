using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser
{
    public class GetUserUseCaseDataResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public string Gender { get; set; }
        public int? Point { get; set; }
        public string UserStatus { get; set; }
    }
}
