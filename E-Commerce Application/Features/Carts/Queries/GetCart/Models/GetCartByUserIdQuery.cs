using E_Commerce_Application.Features.Carts.Queries.GetCart.Results;
using MediatR;

namespace E_Commerce_Application.Features.Carts.Queries.GetCart.Models
{
    public class GetCartByUserIdQuery: IRequest<CartResponse>
    {
        public string UerId {  get; set; }
    }
}