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
}