using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.UpdateProduct.Models
{
    public class UpdateProductCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } 
    }
}
