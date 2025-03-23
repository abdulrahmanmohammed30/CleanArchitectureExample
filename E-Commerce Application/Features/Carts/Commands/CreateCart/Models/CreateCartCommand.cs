using E_Commerce_Application.Features.Carts.Commands.CreateCart.Models;
using E_Commerce_Application.Features.Carts.Queries.GetCart.Results;
using MediatR;

namespace E_Commerce_Application.Services
{
        public class CreateCartCommand: IRequest<CartResponse>
        {
            public string UserId { get; init; }
            public ICollection<CreateCartItemCommand> CartItems { get; init; }
        }
}
