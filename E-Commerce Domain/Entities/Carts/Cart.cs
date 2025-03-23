using E_Commerce_Domain.Identity;

namespace E_Commerce_Domain.Entities.Carts
{
    public class Cart
    {
        public int Id { get; init; }
        public string UserId { get; init; }
        public User User { get; init; }
        public ICollection<CartItem> CartItems { get; init; } = new List<CartItem>();
    }
}
