using E_Commerce_Application.Features.Carts.Commands.UpdateCart.Models;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class UpdateCartCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<UpdateCartItemCommand> CartItems { get; set; } = new List<UpdateCartItemCommand>();
    }
}
