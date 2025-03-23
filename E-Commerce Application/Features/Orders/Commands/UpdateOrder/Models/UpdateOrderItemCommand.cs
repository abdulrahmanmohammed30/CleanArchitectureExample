namespace E_Commerce_Application.Features.Orders.Commands.UpdateOrder.Models
{
    public class UpdateOrderItemCommand
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
