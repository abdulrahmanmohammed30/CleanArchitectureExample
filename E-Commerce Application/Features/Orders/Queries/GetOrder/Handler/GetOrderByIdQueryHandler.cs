using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Orders.Commands.CreateOrder.Handler;

namespace E_Commerce_Application.Services
{
    public partial class OrderReadService
    {
        public class GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            public async Task<GetOrderResponse> GetOrderByIdAsync(int id)
            {
                var order = await orderRepository.GetOrderByIdAsync(id);
                if (order == null) return null;

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

}
