using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUserById
{
    public class GetUserByIdUseCaseOutput : UseCaseOutputBase
    {
        public GetUserUseCaseDataResponse DataResponseUser { get; set; }
    }
}
