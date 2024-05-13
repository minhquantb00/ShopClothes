using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductImage
{
    public class CreateProductImageUseCase : IUseCase<List<CreateProductImageUseCaseInput>, CreateProductImageUseCaseOutput>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductImage> _productImageRepository;
        public CreateProductImageUseCase(IRepository<Product> productRepository, IRepository<ProductImage> productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }

        public async Task<CreateProductImageUseCaseOutput> ExcuteAsync(int? id, List<CreateProductImageUseCaseInput> input)
        {
            CreateProductImageUseCaseOutput response = new CreateProductImageUseCaseOutput
            {
                Succeeded = false
            };
            try
            {
                var product = await _productRepository.GetAsync(record => record.Id == id);
                if (product == null)
                {
                    response.Errors = new string[] { "Sản phẩm không tồn tại" };
                    return response;
                }
                List<ProductImage> listDetail = new List<ProductImage>();
                foreach (var productDetail in input)
                {
                    ProductImage item = new ProductImage
                    {
                        ImageUrl = await HandleUploadImage.Upfile(productDetail.File),
                        ProductId = product.Id
                    };
                    listDetail.Add(item);
                    item = await _productImageRepository.CreateAsync(item);
                }
                product.ProductImages = listDetail;
                await _productRepository.UpdateAsync(product);
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateProductImageUseCaseOutput> ExcuteAsync(List<CreateProductImageUseCaseInput> input)
        {
            throw new NotImplementedException();
        }
    }
}
