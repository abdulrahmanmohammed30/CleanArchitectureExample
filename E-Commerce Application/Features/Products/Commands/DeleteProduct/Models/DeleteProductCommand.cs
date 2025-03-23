using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.DeleteProduct.Models
{
    public class DeleteProductCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
