
using E_Commerce_Application.Features.Orders.Commands.CreateOrder.Handler;

public class GetOrderResponse{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public ICollection<OrderItemResponse> OrderItems { get; set; }
}
