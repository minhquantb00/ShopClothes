using AutoMapper;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser
{
    public class GetUserUseCaseMapping
    {
        public GetUserUseCaseDataResponse EntityToDTO(User user)
        {
            return new GetUserUseCaseDataResponse
            {
                AvatarUrl = user.AvatarUrl != "" ? user.AvatarUrl : "",
                Email = user.Email != "" ? user.Email : "",
                FullName = user.FullName != "" ? user.FullName : "",
                Gender = user.Gender != null ? user.Gender.ToString() : null,
                PhoneNumber = user.PhoneNumber != "" ? user.PhoneNumber : "",
                Point = user.Point != 0 ? user.Point : 0,
                UserStatus = user.UserStatus != null ? user.UserStatus.ToString() : null
            };
        }
    }
}
