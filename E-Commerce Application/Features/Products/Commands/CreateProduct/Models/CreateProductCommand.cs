using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;
using ErrorOr;
using MediatR;

namespace E_Commerce_Application.Features.Products.Commands.CreateProduct.Models
{

    public class CreateProductCommand: IRequest<ErrorOr<GetProductResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
