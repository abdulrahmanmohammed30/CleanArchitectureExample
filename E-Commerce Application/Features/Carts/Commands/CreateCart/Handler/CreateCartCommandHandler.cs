using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Carts.Queries.GetCart.Results;
using E_Commerce_Domain.Entities.Carts;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class CreateCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCartCommand, CartResponse>
    {
        public async Task<CartResponse> Handle(CreateCartCommand createCartDto, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                UserId = createCartDto.UserId,
                CartItems = createCartDto.CartItems.Select(ci => new CartItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            await cartRepository.CreateCartAsync(cart);
            await unitOfWork.CommitChangesAsync();
            return new CartResponse
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CartItems = cart.CartItems.Select(ci => new CartItemResponse
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }
    }
}
