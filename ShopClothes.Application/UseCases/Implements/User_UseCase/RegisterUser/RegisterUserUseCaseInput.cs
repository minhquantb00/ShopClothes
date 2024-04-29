using Newtonsoft.Json;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = System.Text.Json.Serialization.JsonConverterAttribute;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser
{
    public class RegisterUserUseCaseInput
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "FullName is required")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GenderEnum Gender { get; set; } = GenderEnum.Unknown;
    }
}
