using E_Commerce_Application.Common.interfaces;
using E_Commerce_Infrastructure.Common.Persistence;
using E_Commerce_Infrastructure.Features.Carts.Persistence;
using E_Commerce_Infrastructure.Features.Orders.Persistence;
using E_Commerce_Infrastructure.Features.Products.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace E_Commerce_Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider=> serviceProvider.GetRequiredService<ApplicationDbContext>());


            return services;
        }
    }
}
