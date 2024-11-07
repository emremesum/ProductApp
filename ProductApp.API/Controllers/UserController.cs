using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Services.Products;
using ProductApp.Services.Users;

namespace ProductApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
	[HttpGet("{role}")]
	[Authorize(Roles = "Admin")]

	public async Task<IActionResult> GetAll(string role)
	{
		var productResult = await userService.GetAllAsync(role);
		if (productResult.Data.Count==0)
		{
			return NotFound();
		}
		
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
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var productResult = await userService.CreateUserAsync(request);

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
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserRequest request)
	{


		var updateResult = await userService.UpdateUserAsync(id, request);
		if (updateResult.IsSuccess)
		{
			return Ok();
		}

		return BadRequest(updateResult.ErrorMessage);
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteAsync(int id)
	{
		var productResult = await userService.DeleteUserAsync(id);
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
