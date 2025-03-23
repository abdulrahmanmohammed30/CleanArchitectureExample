using MediatR;

namespace E_Commerce_Application.Features.Orders.Commands.DeleteOrder.Models
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
