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
        var productResult= await productService.GetAllListAsync();
        if (productResult.IsSuccess)
        {
            return Ok(productResult.Data);

        }
        else
        {
            return BadRequest(productResult.ErrorMessage);
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductRequest request )
    {
        var productResult = await productService.UpdateAsync(request);
        if (productResult.IsSuccess)
        {
            return Ok(productResult.IsSuccess);

        }
        else
        {
            return BadRequest(productResult.ErrorMessage);
        }
    }
   
    [HttpPost("create")]
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

    [HttpPost("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var productResult = await productService.GetByIdAsync(id);
        if (productResult.IsSuccess)
        {
            return Ok(productResult.Data);

        }
        else
        {
            return BadRequest(productResult.ErrorMessage);
        }
    }
}