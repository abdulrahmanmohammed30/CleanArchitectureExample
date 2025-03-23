using E_Commerce_Domain.Entities.Products;

namespace E_Commerce_Domain.Entities.Carts
{
    public class CartItem
    {
        public int Id { get; init; }
        public int CartId { get; init; }
        public Cart Cart { get; init; }
        public int ProductId { get; init; }
        public Product Product { get; init; }
        public int Quantity { get; init; }
    }
}
