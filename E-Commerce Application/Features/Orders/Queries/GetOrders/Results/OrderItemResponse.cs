namespace E_Commerce_Application.Features.Orders.Commands.CreateOrder.Handler
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}