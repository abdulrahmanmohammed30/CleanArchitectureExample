using E_Commerce_Application.Features.Orders.Queries.GetOrders.Results;
using MediatR;

namespace E_Commerce_Application.Features.Orders.Queries.GetOrders.Models
{
    public class GetOrdersByUserIdQuery: IRequest<GetOrderListResponse>
    {
        public string UserId { get; set; }
    }
}
