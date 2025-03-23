
namespace E_Commerce_Application.Features.Carts.Commands.DTOs
{
    public class CreateCartDto
    {
        public string UserId { get; set; }
        public List<CreateCartItemDto> CartItems { get; set; }
    }
}
