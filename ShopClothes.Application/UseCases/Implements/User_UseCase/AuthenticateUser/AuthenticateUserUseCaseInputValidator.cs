using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser
{
    public class AuthenticateUserUseCaseInputValidator : AbstractValidator<AuthenticateUserUseCaseInput>
    {
        public AuthenticateUserUseCaseInputValidator()
        {
            RuleFor(x => x.ConfirmCode)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("ConfirmCode should be has value");
        }
    }
}
