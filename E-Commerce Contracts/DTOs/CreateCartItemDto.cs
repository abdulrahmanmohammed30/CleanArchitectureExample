namespace E_Commerce_Application.Features.Carts.Commands.DTOs
{
    public class CreateCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}