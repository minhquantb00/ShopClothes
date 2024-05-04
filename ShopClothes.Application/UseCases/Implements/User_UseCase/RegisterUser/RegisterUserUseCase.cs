using Org.BouncyCastle.Asn1.Ocsp;
using ShopClothes.Application.Handle.HandleEmail;
using ShopClothes.Application.InterfaceService;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using ShopClothes.Domain.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser
{
    public class RegisterUserUseCase : IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        private readonly IEmailService _emailService;
        public RegisterUserUseCase(IRepository<User> userRepository, IRepository<ConfirmEmail> confirmEmailRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _confirmEmailRepository = confirmEmailRepository;
            _emailService = emailService;
        }
        public async Task<RegisterUserUseCaseOutput> ExcuteAsync(RegisterUserUseCaseInput input)
        {
            var resultOutput = new RegisterUserUseCaseOutput
            {
                Succeeded = false,
            };
            try
            {
                if (!ValidateValue.IsValidEmail(input.Email))
                {
                    resultOutput.Errors = new string[] { $"Định dạng email không hợp lệ" };
                    return resultOutput;
                }
                if (!ValidateValue.IsValidPhoneNumber(input.PhoneNumber))
                {
                    resultOutput.Errors = new string[] { $"Định dạng số điện thoại không hợp lệ" };
                    return resultOutput;
                }
                if(_userRepository.GetUserByUsername(input.UserName).Result != null)
                {
                    resultOutput.Errors = new string[] { "Tài khoản đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                if (_userRepository.GetUserByPhoneNumber(input.PhoneNumber).Result != null)
                {
                    resultOutput.Errors = new string[] { "Số điện thoại đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                if (_userRepository.GetUserByEmail(input.Email).Result != null)
                {
                    resultOutput.Errors = new string[] { "Email đã tồn tại trên hệ thống" };
                    return resultOutput;
                }
                var user = new User
                {
                    UserName = input.UserName,
                    Password = BcryptNet.HashPassword(input.Password),
                    AvatarUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5zThKtjx7rImritWaiC62PPk65OYt70P7qA&usqp=CAU",
                    CreateTime = DateTime.Now,
                    Email = input.Email,
                    FullName = input.FullName,
                    Gender = input.Gender,
                    PhoneNumber = input.PhoneNumber,
                    UserStatus = Domain.Enumerates.UserStatusEnum.UnActivated
                };
                user = await _userRepository.CreateAsync(user);
                if (user.Id != null && user.Id != 0)
                {
                    await _userRepository.AddUserToRoleAsync(user, new string[] { "User" });
                    
                    ConfirmEmail confirmEmail = new ConfirmEmail
                    {
                        ConfirmCode = GenerateCodeActive(),
                        ExpiryTime = DateTime.Now.AddMinutes(1),
                        IsConfirmed = false,
                        UserId = user.Id,
                    };
                    confirmEmail = await _confirmEmailRepository.CreateAsync(confirmEmail);
                    var message = new EmailMessage(new string[] { user.Email }, "Nhận mã xác nhận để kích hoạt tài khoản tại đây: ", $"Mã xác nhận là: {confirmEmail.ConfirmCode}");
                    _emailService.SendEmail(message);
                    resultOutput.Succeeded = true;
                    return resultOutput;
                }
                resultOutput.Errors = new string[] { "User registration failed" };
                return resultOutput;
            }
            catch
            {
                throw;
            }
        }
        private string GenerateCodeActive()
        {
            return "MyBugsShop_" + DateTime.Now.Ticks.ToString();
        }
    }
}
