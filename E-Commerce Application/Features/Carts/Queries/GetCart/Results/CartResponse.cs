
using E_Commerce_Application.Services;

namespace E_Commerce_Application.Features.Carts.Queries.GetCart.Results
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItemResponse> CartItems { get; set; }
    }
}
