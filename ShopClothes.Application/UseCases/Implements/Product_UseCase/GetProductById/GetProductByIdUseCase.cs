using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.GetProduct;
using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUserById;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.GetProductById
{
    public class GetProductByIdUseCase : IUseCaseGetById<int, GetProductByIdUseCaseOutput>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly GetProductUseCaseMappingProduct _mapper;
        public GetProductByIdUseCase(IRepository<Product> productRepository, GetProductUseCaseMappingProduct mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductByIdUseCaseOutput> ExcuteAsync(int id)
        {
            var result = _mapper.EntityToDTO(_productRepository.GetByIdAsync(id).Result);

            GetProductByIdUseCaseOutput response = new GetProductByIdUseCaseOutput
            {
                Succeeded = true,
                DataResponseProduct = result
            };
            return response;
        }
    }
}
