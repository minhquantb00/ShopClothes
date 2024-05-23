using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.GetProductById;
using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.CreateProductReview;
using ShopClothes.Application.UseCases.Implements.ProductReview_UseCase.GetProductReview;
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
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetProductUseCaseInput, GetProductUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetProductByIdUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateProductReview([FromForm] CreateProductReviewUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateProductReviewUseCaseInput, CreateProductReviewUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductReview(GetProductReviewUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<GetProductReviewUseCaseInput, GetProductReviewUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductReviewById([FromRoute] int id)
        {
            var useCase = _serviceProvider.GetService<IUseCaseGetById<int, GetProductReviewUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
