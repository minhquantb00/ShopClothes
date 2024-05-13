using ShopClothes.Application.Handle.HandleImage;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProductDetail
{
    public class CreateProductDetailUseCase : IUseCase<List<CreateProductDetailUseCaseInput>, CreateProductDetailUseCaseOutput>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductDetail> _productDetailRepository;
        public CreateProductDetailUseCase(IRepository<Product> productRepository, IRepository<ProductDetail> productDetailRepository)
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
        }

        public async Task<CreateProductDetailUseCaseOutput> ExcuteAsync(int? id, List<CreateProductDetailUseCaseInput> input)
        {
            CreateProductDetailUseCaseOutput response = new CreateProductDetailUseCaseOutput
            {
                Succeeded = false
            };
            try
            {
                var product = await _productRepository.GetAsync(record => record.Id == id);
                if(product == null)
                {
                    response.Errors = new string[] { "Sản phẩm không tồn tại" };
                    return response;
                }
                List<ProductDetail> listDetail = new List<ProductDetail>();
                foreach(var productDetail in input)
                {
                    ProductDetail item = new ProductDetail
                    {
                        ColorId = productDetail.ColorId,
                        CreateTime = DateTime.Now,
                        Image = await HandleUploadImage.Upfile(productDetail.Image),
                        ProductDetailStatus = Domain.Enumerates.ProductDetailStatusEnum.Stocking,
                        ProductId = product.Id,
                        ReturnQuantity = 0,
                        InventoryNumber = 0,
                        SizeId = productDetail.SizeId,
                        SoldQuantity = 0
                    };
                    listDetail.Add(item);
                    item = await _productDetailRepository.CreateAsync(item);
                }
                product.ProductDetails = listDetail;
                await _productRepository.UpdateAsync(product);
                response.Succeeded = true;
                return response;

            }catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
                return response;
            }
        }

        public Task<CreateProductDetailUseCaseOutput> ExcuteAsync(List<CreateProductDetailUseCaseInput> input)
        {
            throw new NotImplementedException();
        }
    }
}
