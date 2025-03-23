namespace E_Commerce_Application.Features.Carts.Commands.CreateCart.Models
{
    public class CreateCartItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}