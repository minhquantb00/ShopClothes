using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ChangePasswordUser
{
    public class ChangePasswordUserUseCaseInputValidator : AbstractValidator<ChangePasswordUserUseCaseInput>
    {
        public ChangePasswordUserUseCaseInputValidator()
        {
            RuleFor(x => x.OldPassword)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("OldPassword should be has value");
            RuleFor(x => x.NewPassword)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("NewPassword should be has value");
            RuleFor(x => x.ConfirmPassword)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("ConfirmPassword should be has value");
        }
    }
}
