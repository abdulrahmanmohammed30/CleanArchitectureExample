using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Orders.Commands.DeleteOrder.Models;
using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.DeleteOrder.Handler
{
    class DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork): IRequestHandler<DeleteOrderCommand, bool>
    {
       public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.DeleteOrderAsync(request.Id);
            await unitOfWork.CommitChangesAsync();
            return true;
        }
    }
}
