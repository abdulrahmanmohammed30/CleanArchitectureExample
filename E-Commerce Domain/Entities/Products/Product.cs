using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Domain.Entities.Products
{
    public class Product
    {
        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string Name { get; init; }

        public string Description { get; init; }

        [Range(0.01, 999999.99)]
        public decimal Price { get; init; }
    }
}
