using Blog.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Commands.OrderDetails;
using Blog.Application.Queries.GetOrderDetails;
using Blog.Common.Constants;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderDetailsController : Controller
    {
        private readonly ISender _sender;
        public OrderDetailsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetOrderList")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<OrderDetailsDTO>>> GetOrderDetailAsync()
        {
            var orderDetail = await _sender.Send(new GetOrderDetailsQuery());
            return Ok(orderDetail);
        }

        [HttpGet("GetOrderById/{detailsId}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<OrderDetailsDTO>> GetOrderDetailsById(Guid detailsId)
        {
            var orderDetail = await _sender.Send(new GetOrderDetailsByIdQuery(detailsId));
            return Ok(orderDetail);
        }


        [HttpPost("CreateOrderDetails")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> CreateOrderDetailsAsync(CreateOrderDetailsDTO createOrder)
        {
            var orderCommand = new CreateOrderDetailsCommand(
                Guid.NewGuid(),
                createOrder.ProductId,
                createOrder.Quantity,
                createOrder.UnitPrice,
                createOrder.ShippedDate
                );

            try
            {
                await _sender.Send(orderCommand);

            }

            catch (Exception ex)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", ControllerConstants.OrderDetails,
                new {orderCommand.OrderDetailId }, orderCommand);
        }

        [HttpPut("UpdateOrderDetails")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateOrderDetailsAsync(UpdateOrderDetailsDTO updateOrder, Guid OrderDetailId)
        {
            if (updateOrder.OrderDetailId != OrderDetailId)
            {
                return BadRequest();
            }

            var orderCommand = new UpdateOrderDetailsCommand(
                updateOrder.ProductsId,
                updateOrder.OrderId,
                updateOrder.Quantity,
                updateOrder.UnitPrice,
                updateOrder.ShippedDate
                );

            try
            {
                await _sender.Send(orderCommand);
            }
            catch (Exception)
            {

                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("DelteOrderDetails")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrderDetailsAsync(Guid OrderDetailId)
        {
            var deleteCommand = new DeleteOrderDetailsCommand(OrderDetailId);
            try
            {
                await _sender.Send(deleteCommand);
            }
            catch (Exception)
            {

                return NotFound();
            }
            return NoContent();
        }
    }
}
