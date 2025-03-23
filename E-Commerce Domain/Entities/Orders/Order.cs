using E_Commerce_Domain.Identity;

namespace E_Commerce_Domain.Entities.Order
{
    public class Order
    {
        public int Id { get; init;  }
        public DateTime OrderDate { get; init; }
        public string UserId { get; init; }
        public User User { get; init; }
        public ICollection<OrderItem> OrderItems { get; init; } = new List<OrderItem>();
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
    }
}
