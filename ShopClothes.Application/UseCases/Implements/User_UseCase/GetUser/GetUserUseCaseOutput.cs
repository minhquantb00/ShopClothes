using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser
{
    public class GetUserUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<GetUserUseCaseDataResponse> DataResponseUser { get; set; }
    }
}
