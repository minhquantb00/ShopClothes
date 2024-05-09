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
                AvatarUrl = user.AvatarUrl,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender.ToString(),
                PhoneNumber = user.PhoneNumber,
                Point = user.Point,
                UserStatus = user.UserStatus.ToString()
            };
        }
    }
}
