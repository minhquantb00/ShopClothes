using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.ChangePasswordUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ConfirmCreateNewPasswordUser
{
    public class ConfirmCreateNewPasswordUserUseCaseInputValidator : AbstractValidator<ConfirmCreateNewPasswordUserUseCaseInput>
    {
        public ConfirmCreateNewPasswordUserUseCaseInputValidator()
        {
            RuleFor(x => x.ConfirmCode)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("ConfirmCode should be has value");
            RuleFor(x => x.NewPassword)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("NewPassword should be has value");
            RuleFor(x => x.ConfirmNewPassword)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("ConfirmNewPassword should be has value");
        }
    }
}
