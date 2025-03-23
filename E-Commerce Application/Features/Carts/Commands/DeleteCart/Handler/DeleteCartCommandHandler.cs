using E_Commerce_Application.Common.interfaces;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class DeleteCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCartCommand, bool>
    {
        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            await cartRepository.DeleteCartAsync(request.Id);
            await unitOfWork.CommitChangesAsync();
            return true;
        }
    }
}