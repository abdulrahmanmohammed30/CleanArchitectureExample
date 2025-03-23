using E_Commerce_Domain.Entities.Carts;
using E_Commerce_Domain.Entities.Order;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Domain.Identity
{
    public class User : IdentityUser
    {
        public string FullName { get; init; }
        public ICollection<Cart> Carts { get; init;  } = new List<Cart>();
        public ICollection<Order> Orders { get; init; } = new List<Order>();
    }
}
