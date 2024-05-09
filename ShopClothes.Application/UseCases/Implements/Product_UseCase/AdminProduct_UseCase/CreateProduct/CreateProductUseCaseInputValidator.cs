
using FluentValidation;
using ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProduct
{
    internal class CreateProductUseCaseInputValidator: AbstractValidator<CreateProductUseCaseInput>
    {
        public CreateProductUseCaseInputValidator()
        {
            RuleFor(x => x.ProductName)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Product name should be has value");
        }
    }
}
