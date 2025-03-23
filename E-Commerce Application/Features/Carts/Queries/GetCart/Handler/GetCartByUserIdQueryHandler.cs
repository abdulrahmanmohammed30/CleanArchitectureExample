
using E_Commerce_Application.Common.interfaces;
using E_Commerce_Application.Features.Carts.Queries.GetCart.Models;
using E_Commerce_Application.Features.Carts.Queries.GetCart.Results;
using E_Commerce_Application.Services;
using MediatR;

public class GetCartByUserIdQueryHandler(ICartRepository cartRepository) : IRequestHandler<GetCartByUserIdQuery, CartResponse>
{
    public async Task<CartResponse> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetCartByUserIdAsync(request.UerId);
        if (cart == null)
        {
            return null;
        }

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