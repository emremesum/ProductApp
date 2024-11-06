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

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateProductRequest request)
    //{
    //    //return await productService.CreateWithoutImageAsync(request);

    //}
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

    [HttpPost]
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