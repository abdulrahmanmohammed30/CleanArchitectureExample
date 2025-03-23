using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Products.Commands.DeleteProduct.Models;
using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.DeleteProduct.Handlers
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteProductAsync(request.Id);
            await unitOfWork.CommitChangesAsync();
            return true;
        }
    }
}
