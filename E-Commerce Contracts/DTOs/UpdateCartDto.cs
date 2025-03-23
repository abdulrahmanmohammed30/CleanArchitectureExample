
using E_Commerce_Contracts.DTOs;

namespace E_Commerce_Application.Features.Carts.Commands.DTOs
{
    public class UpdateCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<UpdateCartItemDto> CartItems { get; set; }
    }
}
