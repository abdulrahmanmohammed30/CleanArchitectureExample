using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;
using ErrorOr;
using MediatR;

namespace E_Commerce_Application.Features.Products.Queries.GetProduct.Models
{
    public class GetProductByIdQuery : IRequest<ErrorOr<GetProductResponse>>
    {
        public int Id { get; set; }
    }
}
