using NETCore.MailKit.Core;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.Handle.HandleEmail;
using ShopClothes.Application.InterfaceService;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEmailService = ShopClothes.Application.InterfaceService.IEmailService;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ForgotPasswordUser
{
    public class ForgotPasswordUserUseCase : IUseCase<ForgotPasswordUserUseCaseInput, ForgotPasswordUserUseCaseOuput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        private readonly IEmailService _emailService;
        public ForgotPasswordUserUseCase(IRepository<User> userRepository, IRepository<ConfirmEmail> confirmEmailRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _confirmEmailRepository = confirmEmailRepository;
            _emailService = emailService;
        }
        public async Task<ForgotPasswordUserUseCaseOuput> ExcuteAsync(ForgotPasswordUserUseCaseInput input)
        {
            ForgotPasswordUserUseCaseOuput response = new ForgotPasswordUserUseCaseOuput
            {
                Succeeded = false
            };
            try
            {
                var user = await _userRepository.GetUserByEmail(input.Email);
                if(user == null)
                {
                    response.Errors = new string[] { "Email không tồn tại trên hệ thống" };
                    return response;
                }
                ConfirmEmail confirmEmail = new ConfirmEmail
                {
                    ConfirmCode = ApplicationConstant.Constant.GenerateCodeActive(),
                    ExpiryTime = DateTime.Now.AddMinutes(3),
                    IsConfirmed = false,
                    UserId = user.Id
                };
                confirmEmail = await _confirmEmailRepository.CreateAsync(confirmEmail);
                var message = new EmailMessage(new string[] { user.Email }, "Nhận mã xác nhận tại đây: ", $"Mã xác nhận là: {confirmEmail.ConfirmCode}");
                _emailService.SendEmail(message);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                response.Succeeded = false;
                return response;
            }
        }
    }
}
