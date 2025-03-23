using E_Commerce_Application.Common.interfaces;
using E_Commerce_Domain.Entities.Carts;
using MediatR;

namespace E_Commerce_Application.Services
{
    public class UpdateCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork): IRequestHandler<UpdateCartCommand>
    {
        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                Id = request.Id,
                UserId = request.UserId,
                CartItems = request.CartItems.Select(ci => new CartItem
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            await cartRepository.UpdateCartAsync(cart);
            await unitOfWork.CommitChangesAsync();
        }
    }
}
