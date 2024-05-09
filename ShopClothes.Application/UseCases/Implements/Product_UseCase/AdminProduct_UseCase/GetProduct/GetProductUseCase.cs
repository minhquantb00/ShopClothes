using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct
{
    public class GetProductUseCase : IUseCase<GetProductUseCaseInput, GetProductUseCaseOutput>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Product> _productRepository;
        private readonly 
        public async Task<GetProductUseCaseOutput> ExcuteAsync(GetProductUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
