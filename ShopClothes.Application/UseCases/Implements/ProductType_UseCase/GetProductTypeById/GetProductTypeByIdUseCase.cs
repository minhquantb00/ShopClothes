using ShopClothes.Application.UseCases.Implements.ProductType_UseCase.DataProductType;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.ProductType_UseCase.GetProductTypeById
{
    public class GetProductTypeByIdUseCase : IUseCaseGetById<int, GetProductTypeByIdUseCaseOutput>
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly ProductTypeConverter _productTypeConverter;
        public GetProductTypeByIdUseCase(IRepository<ProductType> productTypeRepository, ProductTypeConverter productTypeConverter)
        {
            _productTypeRepository = productTypeRepository;
            _productTypeConverter = productTypeConverter;
        }

        public async Task<GetProductTypeByIdUseCaseOutput> ExcuteAsync(int id)
        {
            var query = await _productTypeRepository.GetAsync(item => item.Id == id);
            return new GetProductTypeByIdUseCaseOutput
            {
                Succeeded = true,
                DataResponseProductType = _productTypeConverter.EntityToDTO(query)
            };
        }
    }
}
