using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Orders.Commands.UpdateOrder.Models;
using E_Commerce_Domain.Entities.Order;
using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.UpdateOrder.Handler
{
    public class UpdateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateOrderCommand>
    {
        public async Task Handle(UpdateOrderCommand updateOrderDto, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = updateOrderDto.Id,
                OrderDate = updateOrderDto.OrderDate,
                UserId = updateOrderDto.UserId,
                OrderItems = updateOrderDto.OrderItems.Select(oi => new OrderItem
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList()
            };

            await orderRepository.UpdateOrderAsync(order);
            await unitOfWork.CommitChangesAsync();
        }
    }
}
