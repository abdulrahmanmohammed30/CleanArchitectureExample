using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Orders.Commands.CreateOrder.Handler;
using E_Commerce_Application.Features.Orders.Queries.GetOrders.Models;
using E_Commerce_Application.Features.Orders.Queries.GetOrders.Results;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository): IRequestHandler<GetOrdersByUserIdQuery, GetOrderListResponse>
    {
        public async Task<GetOrderListResponse> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrdersByUserIdAsync(request.UserId);
            return new GetOrderListResponse()
            {
                Orders = orders.Select(order => new GetOrderResponse
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
                }).ToList()
            };
        }
    }
}
