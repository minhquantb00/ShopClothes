using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser
{
    public class LoginUserUseCaseInputValidator : AbstractValidator<LoginUserUseCaseInput>
    {
        public LoginUserUseCaseInputValidator()
        {
            RuleFor(x => x.UserName)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("FullName should be has value");
            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("FullName should be has value");
        }
    }
}
