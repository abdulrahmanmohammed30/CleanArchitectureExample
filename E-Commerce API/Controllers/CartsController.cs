using Microsoft.AspNetCore.Mvc;
using MediatR;
using E_Commerce_Application.Features.Carts.Queries.GetCart.Models;
using E_Commerce_Application.Services;
using E_Commerce_Application.Features.Carts.Commands.DTOs;
using E_Commerce_Application.Features.Carts.Commands.UpdateCart.Models;
using E_Commerce_Application.Features.Carts.Commands.CreateCart.Models;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(ISender mediator) : ControllerBase
    {

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDto>> GetCartAsync(string userId)
        {
            var query = new GetCartByUserIdQuery() { UerId = userId };

            var cart = await mediator.Send(query);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<CartDto>> CreateCartAsync(CreateCartDto createCartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = new CreateCartCommand()
            {
                UserId = createCartDto.UserId,
                CartItems = createCartDto.CartItems.Select(cartItem => new CreateCartItemCommand()
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                }).ToList()
            };

            var cart = await mediator.Send(request);
            return CreatedAtAction(nameof(GetCartAsync), new { userId = cart.UserId }, cart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartAsync(int id, UpdateCartDto updateCartDto)
        {
            if (id != updateCartDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateCartCommand()
            {
                Id = updateCartDto.Id,
                UserId = updateCartDto.UserId,
                CartItems = updateCartDto.CartItems.Select(c => new UpdateCartItemCommand()
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                }).ToList()
            };

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartAsync(int id)
        {
            var command = new DeleteCartCommand()
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
