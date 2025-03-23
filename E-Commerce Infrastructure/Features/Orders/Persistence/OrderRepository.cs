using E_Commerce_Application.Common.interfaces;
using E_Commerce_Domain.Entities.Order;
using E_Commerce_Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Infrastructure.Features.Orders.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            return Task.CompletedTask;
        }

        public Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }
    }
}
