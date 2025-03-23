namespace E_Commerce_Contracts.DTOs
{
    public class UpdateCartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
