using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ConfirmCreateNewPasswordUser
{
    public class ConfirmCreateNewPasswordUserUseCase : IUseCase<ConfirmCreateNewPasswordUserUseCaseInput, ConfirmCreateNewPasswordUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        public ConfirmCreateNewPasswordUserUseCase(IRepository<User> userRepository, IRepository<ConfirmEmail> confirmEmailRepository)
        {
            _userRepository = userRepository;
            _confirmEmailRepository = confirmEmailRepository;
        }

        public async Task<ConfirmCreateNewPasswordUserUseCaseOutput> ExcuteAsync(ConfirmCreateNewPasswordUserUseCaseInput input)
        {
            ConfirmCreateNewPasswordUserUseCaseOutput response = new ConfirmCreateNewPasswordUserUseCaseOutput
            {
                Succeeded = false
            };
            try
            {
                var confirmEmail = await _confirmEmailRepository.GetAsync(record => record.ConfirmCode.Equals(input.ConfirmCode));
                if(confirmEmail == null)
                {
                    response.Errors = new string[] { "Mã xác nhận không chính xác" };
                    return response;
                }
                var user = await _userRepository.GetAsync(record => record.Id == confirmEmail.UserId);
                if (!input.NewPassword.Equals(input.ConfirmNewPassword))
                {
                    response.Errors = new string[] { "Mật khẩu không trùng khớp" };
                    return response;
                }
                user.Password = BcryptNet.HashPassword(input.NewPassword);
                user.UpdateTime = DateTime.Now;
                await _userRepository.UpdateAsync(user);
                response.Succeeded = true;
                return response;
            }catch (Exception ex)
            {
                response.Succeeded = false;
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<ConfirmCreateNewPasswordUserUseCaseOutput> ExcuteAsync(int? id, ConfirmCreateNewPasswordUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
