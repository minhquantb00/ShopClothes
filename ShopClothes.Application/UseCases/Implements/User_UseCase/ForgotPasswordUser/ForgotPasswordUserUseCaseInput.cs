using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.ForgotPasswordUser
{
    public class ForgotPasswordUserUseCaseInput
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
