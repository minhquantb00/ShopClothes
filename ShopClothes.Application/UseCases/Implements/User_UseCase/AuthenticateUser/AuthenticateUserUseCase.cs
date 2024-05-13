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
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        public AuthenticateUserUseCase(IRepository<User> userRepository, IConfiguration configuration, IRepository<ConfirmEmail> confirmEmailRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _confirmEmailRepository = confirmEmailRepository;
        }

        public async Task<AuthenticateUserUseCaseOutput> ExcuteAsync(AuthenticateUserUseCaseInput input)
        {
            AuthenticateUserUseCaseOutput response = new AuthenticateUserUseCaseOutput
            {
                Succeeded = false,
            };
            try
            {
                var confirmEmail = await _confirmEmailRepository.GetAsync(record => record.ConfirmCode.Equals(input.ConfirmCode));
                if(confirmEmail == null)
                {
                    response.Errors = new string[] { "Mã xác nhận không chính xác" };
                    return response;
                }
                if(confirmEmail.IsConfirmed == true)
                {
                    response.Errors = new string[] { "Mã xác nhận này đã được sử dụng trước đó" };
                    return response;
                }
                if(confirmEmail.ExpiryTime < DateTime.Now)
                {
                    response.Errors = new string[] { "Mã xác nhận đã hết hạn" };
                    return response;
                }
                var user = await _userRepository.GetAsync(record => record.Id == confirmEmail.UserId);
                if(user == null)
                {
                    response.Errors = new string[] { "Người dùng không tồn tại" };
                    return response;
                }
                user.UserStatus = Domain.Enumerates.UserStatusEnum.Activated;
                await _userRepository.UpdateAsync(user);
                response.Succeeded = true;
                return response;
            }
            catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<AuthenticateUserUseCaseOutput> ExcuteAsync(int? id, AuthenticateUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
