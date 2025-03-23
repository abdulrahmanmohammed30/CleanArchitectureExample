using E_Commerce_Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Domain.Entities.Order
{
    public class OrderItem
    {
        public int Id { get; init; }
        public int OrderId { get; init; }
        public Order Order { get; init; }
        public int ProductId { get; init; }
        public Product Product { get; init; }
        public int Quantity { get; init; }
    }
}
