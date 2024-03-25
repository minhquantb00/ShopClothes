using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser
{
    public class RegisterUserUseCaseInputValidator : AbstractValidator<RegisterUserUseCaseInput>
    {
        public RegisterUserUseCaseInputValidator()
        {
            RuleFor(x => x.FullName)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("FullName should be has value");
        }
    }
}
