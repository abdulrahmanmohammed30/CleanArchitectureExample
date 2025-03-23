using E_Commerce_Application.Features.Products.Queries.GetProduct.Results;

namespace E_Commerce_Application.Features.Products.Queries.GetProducts.Results
{
    public class GetProductListResponse { 
       public List<GetProductResponse> Products { get; set; } = new List<GetProductResponse>();
    }
}
