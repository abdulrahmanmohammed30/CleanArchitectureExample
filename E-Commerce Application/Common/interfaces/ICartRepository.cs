using System.Threading.Tasks;
using E_Commerce_Domain.Entities.Carts;

namespace E_Commerce_Application.Common.interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task CreateCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task DeleteCartAsync(int id);
    }
}
