using System.Threading.Tasks;
using Application.Products.Commands.CreateProduct;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET
        public async Task<ActionResult<Product>> Index(CreateProductCommand productCommand)
        {
            var product = await _mediator.Send(productCommand);
            return product;
        }
    }
}