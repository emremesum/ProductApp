using Microsoft.AspNetCore.Mvc;
using ProductApp.Services.Products;

namespace ProductApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var productResult = await productService.GetAllListAsync();
		if (productResult.IsSuccess)
		{
			return Ok(productResult.Data);

		}
		else
		{
			return BadRequest(productResult.ErrorMessage);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var productResult = await productService.GetByIdAsync(id);
		if (productResult.IsSuccess)
		{
			return Ok(productResult.Data);
		}
		else
		{
			return NotFound(productResult.ErrorMessage);
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var productResult = await productService.CreateWithoutImageAsync(request);

		if (productResult.IsSuccess)
		{
			return Ok(productResult.Data);

		}
		else
		{
			return BadRequest(productResult.ErrorMessage);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProductRequest request)
	{
		var existingProductResult = await productService.GetByIdAsync(id);
		if (!existingProductResult.IsSuccess)
		{
			return NotFound(existingProductResult.ErrorMessage);
		}

		var updateResult = await productService.UpdateAsync(id, request);
		if (updateResult.IsSuccess)
		{
			return Ok();
		}

		return BadRequest(updateResult.ErrorMessage);
	}
	
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAsync(int id)
	{
		var productResult = await productService.DeleteAsync(id);
		if (productResult.IsSuccess)
		{
			return Ok();
		}
		else
		{
			return BadRequest(productResult.ErrorMessage);
		}
	}


}