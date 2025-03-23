    using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;
using E_Commerce_Application.Features.Products.Queries.GetProducts.Models;
using E_Commerce_Application.Features.Products.Queries.GetProducts.Results;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, GetProductListResponse>
    {
        public async Task<GetProductListResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsAsync();
            var result = new GetProductListResponse()
            {
                Products = products.Select(product => new GetProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                }).ToList()
            };

            return result;
        }
    }
}