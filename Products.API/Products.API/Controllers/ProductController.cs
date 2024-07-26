using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.CQRS.Commands;
using Products.API.CQRS.Queries;
using Products.API.DTOs;
using Products.API.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int Page = 1, [FromQuery] int Size = 4)
        {
            ApiResponse<List<ProductResponseDTO>> response = new ApiResponse<List<ProductResponseDTO>>();

            try
            {
                var (products, totalRecords) = await _mediator.Send(new GetProductsQuery
                {
                    Page = Page,
                    Size = Size
                });

                response.Data = products;
                response.Message = "Listado de productos";
                response.TotalRecords = totalRecords;
                response.CurrentPage = Page;

                return Ok(response);
            }
            catch (Exception)
            {
                response.Message = "Error desconocido";
                return BadRequest();
            }
        }



        [HttpGet("gepById/{Id:int}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            ApiResponse<ProductResponseDTO> response = new ApiResponse<ProductResponseDTO>();

            try
            {
                var prod = await _mediator.Send(new GetProductByIdQuery
                {
                    Id = Id
                });

                response.Data = prod;
                response.Message = "Producto buscado";
                response.TotalRecords = 1;
                response.CurrentPage = 1;

                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                response.TotalRecords = 0;
                response.CurrentPage = 0;
                response.Message = $"No existe producto con Id {Id}";
                return NotFound(response);
            }
            catch (Exception)
            {
                response.Message = "Error desconocido";
                return BadRequest();
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }



    }
}
