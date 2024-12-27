using Aplication.Features.Products.Commands;
using Aplication.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		protected readonly IMediator _mediator;
		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var result = await _mediator.Send(new GetProductByIdQuery { Id = id});
			return Ok(result);
		}

		[HttpPost("CreateProduct")]
		public async Task<IActionResult> CreateProducts(CreateProductCommand createProduct, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(createProduct, cancellationToken);
			return Ok(result);
		}
		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProducts(UpdateProductCommand updateProduct, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(updateProduct, cancellationToken);
			return Ok(result);
		}

		[HttpDelete("DeleteProduct/{id}")]
		public async Task<IActionResult> DeleteProducts(int id, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new DeleteProductCommand { Id = id}, cancellationToken);
			return Ok(result);
		}
	}
}
