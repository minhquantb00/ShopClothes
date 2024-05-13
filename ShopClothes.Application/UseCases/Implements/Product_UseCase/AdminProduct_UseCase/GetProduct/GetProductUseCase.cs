using CloudinaryDotNet.Actions;
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
        private readonly GetProductUseCaseMappingProduct _mapper;
        public GetProductUseCase(IHttpContextAccessor httpContextAccessor, IRepository<Product> productRepository, GetProductUseCaseMappingProduct mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductUseCaseOutput> ExcuteAsync(GetProductUseCaseInput input)
        {
            GetProductUseCaseOutput response = new GetProductUseCaseOutput
            {
                Succeeded = false,
            };
            try
            {
                var query = await _productRepository.GetAllAsync();
                if (input.ProductTypeId.HasValue)
                {
                    query = query.Where(record => record.ProductTypeId == input.ProductTypeId);
                }
                if (input.PriceTo.HasValue && !input.PriceForm.HasValue)
                {
                    query = query.Where(record => record.PriceAfterDiscount >= input.PriceTo);
                }
                if (input.PriceForm.HasValue && !input.PriceTo.HasValue)
                {
                    query = query.Where(record => record.PriceAfterDiscount <= input.PriceForm);
                }
                if(input.PriceForm.HasValue && input.PriceTo.HasValue)
                {
                    query = query.Where(record => record.PriceAfterDiscount >= input.PriceTo && record.PriceAfterDiscount <= input.PriceForm);
                }
                if (!string.IsNullOrEmpty(input.Keyword))
                {
                    query = query.Where(record => record.ProductName.ToLower().Contains(input.Keyword.ToLower()));
                }
                response.DataResponseProducts = query.Select(item => _mapper.EntityToDTO(item));
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<GetProductUseCaseOutput> ExcuteAsync(int? id, GetProductUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
