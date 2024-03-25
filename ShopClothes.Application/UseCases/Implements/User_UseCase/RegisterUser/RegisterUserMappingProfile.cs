using AutoMapper;
using ShopClothes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser
{
    public class RegisterUserMappingProfile : Profile
    {
        public RegisterUserMappingProfile() 
        {
            CreateMap<RegisterUserUseCaseInput, User>();
        }
    }
}
