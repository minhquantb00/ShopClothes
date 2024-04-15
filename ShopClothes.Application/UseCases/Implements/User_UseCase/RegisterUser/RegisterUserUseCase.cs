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
        public RegisterUserUseCase(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RegisterUserUseCaseOutput> ExcuteAsync(RegisterUserUseCaseInput input)
        {
            var resultOutput = new RegisterUserUseCaseOutput
            {
                Succeeded = false,
            };
            if(!ValidateValue.IsValidEmail(input.Email))
            {
                resultOutput.Errors = new string[] { $"Invalid email format" };
                return resultOutput;
            }
            if(!ValidateValue.IsValidPhoneNumber(input.PhoneNumber))
            {
                resultOutput.Errors = new string[] { $"Invalid phone number format" };
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
            user =  await _userRepository.CreateAsync(user);
            if(user.Id != null && user.Id != 0)
            {
                await _userRepository.AddUserToRoleAsync(user, new string[] {"User"});
                resultOutput.Succeeded = true;
                return resultOutput;
            }
            resultOutput.Errors = new string[] { "User registration failed" };
            return resultOutput;
        }
    }
}
