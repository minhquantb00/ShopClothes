using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProduct;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductImage;
using ShopClothes.Application.UseCases.Implements.ProductType_UseCase.CreateProductType;
using ShopClothes.Application.UseCases.Implements.ProductType_UseCase.UpdateProductType;

namespace ShopClothes.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AdminController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateProductUseCaseInput, CreateProductUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if(!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateProductImage(int? id, [FromForm] CreateProductImageUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateProductImageUseCaseInput, CreateProductImageUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id, input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateProductDetail(int? id, [FromForm] CreateProductDetailUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateProductDetailUseCaseInput, CreateProductDetailUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(id, input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateProductType([FromBody] CreateProductTypeUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<CreateProductTypeUseCaseInput, CreateProductTypeUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateProductType([FromBody] UpdateProductTypeUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<UpdateProductTypeUseCaseInput, UpdateProductTypeUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
