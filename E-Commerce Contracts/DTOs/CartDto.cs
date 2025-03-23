using System.Collections.Generic;

namespace E_Commerce_Application.Features.Carts.Commands.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
    }
}
