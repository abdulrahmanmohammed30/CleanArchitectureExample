using E_Commerce_Application.Common.interfaces;
using E_Commerce_Domain.Entities.Carts;
using E_Commerce_Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Infrastructure.Features.Carts.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public Task CreateCartAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            return Task.CompletedTask;
        }

        public Task UpdateCartAsync(Cart cart)
        {
            _context.Update(cart);
            return Task.CompletedTask;
        }

        public async Task DeleteCartAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
        }
    }
}
