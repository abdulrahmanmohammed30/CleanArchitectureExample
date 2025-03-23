using E_Commerce_Application.Features.Products.Queries.GetProducts.Results;
using MediatR;

namespace E_Commerce_Application.Features.Products.Queries.GetProducts.Models
{
    public class GetAllProductsQuery : IRequest<GetProductListResponse>
    {

    }
}
