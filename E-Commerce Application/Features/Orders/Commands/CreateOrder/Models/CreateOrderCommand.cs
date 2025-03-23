using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.CreateOrder.Models
{
    public class CreateOrderCommand: IRequest<GetOrderResponse>
    {
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public ICollection<CreateOrderItemCommand> OrderItems { get; set; }
    }
}