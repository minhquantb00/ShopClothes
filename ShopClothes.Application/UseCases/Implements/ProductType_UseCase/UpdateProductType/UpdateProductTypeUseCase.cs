using Microsoft.AspNetCore.Http;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.UpdateProductType
{
    public class UpdateProductTypeUseCase : IUseCase<UpdateProductTypeUseCaseInput, UpdateProductTypeUseCaseOutput>
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateProductTypeUseCase(IRepository<ProductType> productTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productTypeRepository = productTypeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdateProductTypeUseCaseOutput> ExcuteAsync(UpdateProductTypeUseCaseInput input)
        {
            UpdateProductTypeUseCaseOutput response = new UpdateProductTypeUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    response.Succeeded = false;
                    response.Errors = new string[] { "Người dùng chưa được xác thực" };
                    return response;
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    response.Succeeded = false;
                    response.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                }
                var productType = await _productTypeRepository.GetAsync(record => record.Id == input.ProductTypeId);
                if(productType == null)
                {
                    response.Succeeded = false;
                    response.Errors = new string[] { "Loại sản phẩm không tồn tại" };
                    return response;
                }

                productType.ProductTypeName = input.ProductTypeName;
                await _productTypeRepository.UpdateAsync(productType);
                response.Succeeded = true;
                return response;
                
            }catch(Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                response.Succeeded = false;
                return response;
            }
        }

        public Task<UpdateProductTypeUseCaseOutput> ExcuteAsync(int? id, UpdateProductTypeUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
