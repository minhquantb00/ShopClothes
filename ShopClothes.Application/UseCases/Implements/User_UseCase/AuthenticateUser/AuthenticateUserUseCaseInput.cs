using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser
{
    public class AuthenticateUserUseCaseInput
    {
        [Required(ErrorMessage = "ConfirmCode is required")]
        public string ConfirmCode { get; set; }
    }
}
