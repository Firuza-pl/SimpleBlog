using AutoMapper;
using Blog.Application.Commands.ProductCommand;
using Blog.Application.Commands.ProjectCommands;
using Blog.Application.Exceptions;
using Blog.Application.Queries.GetPaginatedProject;
using Blog.Application.Queries.GetProducts;
using Blog.Common.Constants;
using Blog.Shared.DTOs;
using Blog.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        public ProductController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpGet("GetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductAsync()
        {
            var product = await _sender.Send(new GetProductQuery());
            return Ok(product);
        }


        [HttpGet("EditBy/{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(Guid productId)
        {
            var productDTO = await _sender.Send(new GetProductByIdQuery(productId));
            if (productDTO == null)
            {
                return NotFound();
            }
            return Ok(productDTO);
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProduct)
        {

            var productCommand = new CreateProductCommand(
                Guid.NewGuid(),
                createProduct.ProductCode,
                createProduct.ProductName,
                createProduct.Description,
                createProduct.ListPrice,
                createProduct.Status = ProductStatus.Created
                );

            try
            {
                await _sender.Send(productCommand);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProductByIdAsync), ControllerConstants.Product,
                new { ProductId = productCommand.ProductId }, productCommand);

        }

        [HttpPut("UpdateBy/{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDTO updateProductDTO, Guid productId)
        {
            if (productId != updateProductDTO.ProductId)
            {
                return BadRequest();
            }
            var productCommand = new UpdateProductCommand(updateProductDTO.ProductId, updateProductDTO.ProductCode, updateProductDTO.ProductName, updateProductDTO.Description, updateProductDTO.ListPrice);

            try
            {
                await _sender.Send(productCommand);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("DeleteBy/{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteProjectAsync(Guid productId)
        {
            var deleteCommand = new DeleteProductCommand(productId);
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
