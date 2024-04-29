using ShopClothes.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser
{
    public class LoginUserUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseLogin Data { get; set; }
    }
}
