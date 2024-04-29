﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothes.Application.ApplicationConstant;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser;
using System.Reflection.Metadata;
using Constant = ShopClothes.Application.ApplicationConstant.Constant;

namespace ShopClothes.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AuthController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpPost]
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
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserUseCaseInput input)
        {
            var useCase = _serviceProvider.GetService<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>>();
            var result = await useCase.ExcuteAsync(input);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
