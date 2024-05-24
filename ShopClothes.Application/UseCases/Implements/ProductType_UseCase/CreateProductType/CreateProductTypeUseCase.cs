using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.CreateProductType
{
    public class CreateProductTypeUseCase : IUseCase<CreateProductTypeUseCaseInput, CreateProductTypeUseCaseOutput>
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateProductTypeUseCase(IRepository<ProductType> productTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productTypeRepository = productTypeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateProductTypeUseCaseOutput> ExcuteAsync(CreateProductTypeUseCaseInput input)
        {
            CreateProductTypeUseCaseOutput response = new CreateProductTypeUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    response.Errors = new string[] { "Người dùng chưa được xác thực" };
                    response.Succeeded = false;
                    return response;
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                    response.Succeeded = false;
                    return response;
                }
                ProductType productType = new ProductType
                {
                    CreateTime = DateTime.Now,
                    ProductTypeName = input.ProductTypeName,
                };
                productType = await _productTypeRepository.CreateAsync(productType);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateProductTypeUseCaseOutput> ExcuteAsync(int? id, CreateProductTypeUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
