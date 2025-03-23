namespace E_Commerce_Application.Features.Orders.Commands.CreateOrder.Models
{
    public class CreateOrderItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
