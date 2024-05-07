using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.ChangePasswordUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ForgotPasswordUser
{
    public class ForgotPasswordUserUseCaseInputValidator : AbstractValidator<ForgotPasswordUserUseCaseInput>
    {
        public ForgotPasswordUserUseCaseInputValidator()
        {
            RuleFor(x => x.Email)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Email should be has value");
        }
    }
}
