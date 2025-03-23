namespace E_Commerce_Application.Features.Carts.Commands.UpdateCart.Models
{
    public class UpdateCartItemCommand
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
