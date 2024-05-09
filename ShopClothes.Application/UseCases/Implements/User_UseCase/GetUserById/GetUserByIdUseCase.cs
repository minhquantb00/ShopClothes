using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUserById
{
    public class GetUserByIdUseCase : IUseCaseGetById<int, GetUserByIdUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly GetUserUseCaseMapping _mapper;
        public GetUserByIdUseCase(IRepository<User> userRepository, GetUserUseCaseMapping mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdUseCaseOutput> ExcuteAsync(int id)
        {
            GetUserByIdUseCaseOutput response = new GetUserByIdUseCaseOutput
            {
                Succeeded = false
            };
            var user = await _userRepository.GetByIdAsync(id);
            response.DataResponseUser =  _mapper.EntityToDTO(user);
            response.Succeeded = true;
            return response;
        }
    }
}
