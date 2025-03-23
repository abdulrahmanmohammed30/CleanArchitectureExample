using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.DTOs;
using MediatR;
using E_Commerce_Application.Features.Products.Queries.GetProducts.Models;
using E_Commerce_Application.Features.Products.Queries.GetProduct.Models;
using E_Commerce_Application.Features.Products.Commands.CreateProduct.Models;
using E_Commerce_Application.Features.Products.Commands.UpdateProduct.Models;
using E_Commerce_Application.Features.Products.Commands.DeleteProduct.Models;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync()
        {
            var query = new GetAllProductsQuery();

            var products = await mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            var query = new GetProductByIdQuery()
            {
                Id = id
            };

            var product = await mediator.Send(query);
            if (product.IsError)
            {
                return Problem();
            }

            var result = new ProductDto()
            {
                Id = product.Value.Id,
                Name = product.Value.Name,
                Description = product.Value.Description,
                Price = product.Value.Price
            };

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateProductCommand() { 
               Price = createProductDto.Price,
               Name = createProductDto.Name,
               Description = createProductDto.Description
            };

            var result = await mediator.Send(command);
             
            if (result.IsError)
            {
                return Problem();
            }

            return Ok(result.Value);
            //return CreatedAtAction(nameof(GetProductAsync), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateProductCommand()
            {
                Id = id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                Description = updateProductDto.Description
            };

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var command = new DeleteProductCommand()
            {
                Id = id
            };

            var result = await mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
