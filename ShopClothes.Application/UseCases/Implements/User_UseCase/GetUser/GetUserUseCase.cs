using AutoMapper;
using ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.Enumerates;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser
{
    public class GetUserUseCase : IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly GetUserUseCaseMapping _mapper;
        public GetUserUseCase(IRepository<User> userRepository, GetUserUseCaseMapping mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserUseCaseOutput> ExcuteAsync(GetUserUseCaseInput input)
        {
            GetUserUseCaseOutput response = new GetUserUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _userRepository.GetAllAsync(record => record.UserStatus == UserStatusEnum.Activated);
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(item => item.UserName.Equals(input.Keyword) 
                                         || item.Email.Equals(input.Keyword) 
                                         || item.FullName.ToLower().Contains(input.Keyword.ToLower())
                                         || item.PhoneNumber.Trim().Equals(input.Keyword.Trim()));
            }
            response.Succeeded = true;
            response.DataResponseUser = query.Select(item => _mapper.EntityToDTO(item));
            return response;
        }
    }
}
