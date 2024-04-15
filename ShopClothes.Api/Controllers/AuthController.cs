using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser;

namespace ShopClothes.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AuthController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
