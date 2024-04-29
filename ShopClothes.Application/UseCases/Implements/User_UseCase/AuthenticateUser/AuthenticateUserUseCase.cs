using Microsoft.Extensions.Configuration;
using ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser
{
    public class AuthenticateUserUseCase : IUseCase<AuthenticateUserUseCaseInput, AuthenticateUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public AuthenticateUserUseCase(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthenticateUserUseCaseOutput> ExcuteAsync(AuthenticateUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
