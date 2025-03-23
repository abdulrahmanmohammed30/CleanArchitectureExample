using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Products.Commands.CreateProduct.Models;
using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;
using E_Commerce_Domain.Entities.Products;
using ErrorOr;
using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.CreateProduct.Handlers
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, ErrorOr<GetProductResponse>>
    {
        public async Task<ErrorOr<GetProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await productRepository.AddProductAsync(product);
            await unitOfWork.CommitChangesAsync();

            return new GetProductResponse()
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}


