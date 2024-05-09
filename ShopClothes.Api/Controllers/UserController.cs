using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUserById;

namespace ShopClothes.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public UserController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetUserByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
