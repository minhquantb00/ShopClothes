using Microsoft.AspNetCore.Http;
using ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ChangePasswordUser
{
    public class ChangePasswordUserUseCase : IUseCase<ChangePasswordUserUseCaseInput, ChangePasswordUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChangePasswordUserUseCase(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ChangePasswordUserUseCaseOutput> ExcuteAsync(ChangePasswordUserUseCaseInput input)
        {
            ChangePasswordUserUseCaseOutput response = new ChangePasswordUserUseCaseOutput
            {
                Succeeded = false,
            };
            try
            {
                var currentUser = _httpContextAccessor.HttpContext.User;
                if (!currentUser.Identity.IsAuthenticated)
                {
                    response.Errors = new string[] { "Người dùng chưa được xác thực" };
                    return response;
                }
                string userId = currentUser.FindFirst("Id").Value;
                var user = await _userRepository.GetByIdAsync(int.Parse(userId));

                bool checkPassword = BcryptNet.Verify(input.OldPassword, user.Password);
                if(!checkPassword)
                {
                    response.Errors = new string[] { "Mật khẩu không chính xác" };
                    return response;
                }
                if (!input.NewPassword.Equals(input.ConfirmPassword))
                {
                    response.Errors = new string[] { "Mật khẩu không trùng khớp" };
                    return response;
                }
                user.Password = BcryptNet.HashPassword(input.NewPassword);
                user.UpdateTime = DateTime.Now;
                await _userRepository.UpdateAsync(user);
                response.Succeeded = true;
                return response;

            }catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                response.Succeeded = false;
                return response;
            }
        }

        public Task<ChangePasswordUserUseCaseOutput> ExcuteAsync(int? id, ChangePasswordUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
