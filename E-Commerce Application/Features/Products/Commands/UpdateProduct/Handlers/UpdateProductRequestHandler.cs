using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Products.Commands.UpdateProduct.Models;
using E_Commerce_Domain.Entities.Products;
using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.UpdateProduct.Handlers
{
    public class UpdateProductRequestHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await productRepository.UpdateProductAsync(product);
            await unitOfWork.CommitChangesAsync();
        }
    }

}
