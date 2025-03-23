using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.DTOs;
using MediatR;
using E_Commerce_Application.Features.Orders.Queries.GetOrders.Models;
using E_Commerce_Application.Features.Orders.Commands.CreateOrder.Models;
using E_Commerce_Application.Features.Orders.Commands.UpdateOrder.Models;
using E_Commerce_Application.Features.Orders.Commands.DeleteOrder.Models;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAsync(string userId)
        {
            var command = new GetOrdersByUserIdQuery()
            {
                UserId = userId
            };

            var orders = await mediator.Send(command);
            return Ok(orders);
        }

        [HttpGet("{userId}/{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderAsync(string userId, int id)
        {
            var query = new GetOrdersByUserIdQuery()
            {
                UserId = userId,
            };

            var order = await mediator.Send(query);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateOrderCommand()
            {
                UserId = createOrderDto.UserId,
                OrderItems = createOrderDto.OrderItems.Select(o=>new CreateOrderItemCommand()
                {
                    ProductId = o.ProductId, 
                    Quantity = o.Quantity
                }).ToList(),
                OrderDate = createOrderDto.OrderDate,
            };

            var order = await mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderAsync), new { userId = order.UserId, id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
        {
            if (id != updateOrderDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateOrderCommand()
            {
                Id = id,
                UserId = updateOrderDto.UserId,
                OrderDate = updateOrderDto.OrderDate,
                OrderItems = updateOrderDto.OrderItems.Select(o=>new UpdateOrderItemCommand()
                {
                    Id = o.Id,
                    ProductId = o.ProductId, 
                    Quantity = o.Quantity
                }).ToList(),
            }; 

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var command = new DeleteOrderCommand()
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
