using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Products.Queries.GetProduct.Models;
using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;
using ErrorOr;
using MediatR;

namespace E_Commerce_Application.Services
{
    public partial class ProductCommandHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ErrorOr<GetProductResponse>>
    {
        public async Task<ErrorOr<GetProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(request.Id);
            if (product == null) return Error.NotFound();

            return new GetProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}