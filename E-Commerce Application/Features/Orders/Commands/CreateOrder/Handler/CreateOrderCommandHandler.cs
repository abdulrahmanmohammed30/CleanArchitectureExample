using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Orders.Commands.CreateOrder.Models;
using E_Commerce_Domain.Entities.Order;
using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.CreateOrder.Handler
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, GetOrderResponse>
    {
        public async Task<GetOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderDate = request.OrderDate,
                UserId = request.UserId,
                OrderItems = request.OrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList()
            };

            await orderRepository.CreateOrderAsync(order);
            await unitOfWork.CommitChangesAsync();

            return new GetOrderResponse
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponse
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity
                }).ToList()
            };
        }
    }
}
