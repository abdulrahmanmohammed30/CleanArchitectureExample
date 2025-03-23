using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.UpdateOrder.Models
{
    public class UpdateOrderCommand: IRequest
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public string UserId { get; set; }
            public ICollection<UpdateOrderItemCommand> OrderItems { get; set; }
        }
    }
