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
    }
}
