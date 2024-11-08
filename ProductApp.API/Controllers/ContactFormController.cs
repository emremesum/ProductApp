using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Services.Products;
using ProductApp.Services.SupportForm;

namespace ProductApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactFormController(IContactFormService contactFormService) : ControllerBase
	{
		[HttpGet]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> GetAll()
		{
			var productResult = await contactFormService.GetAllListAsync();
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
		[Authorize]
		public async Task<IActionResult> CreateContactFrom([FromBody] CreateContactFormRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var contactFormResult = await contactFormService.CreateAsync(request);

			if (contactFormResult.IsSuccess)
			{
				return Ok(contactFormResult.Data);

			}
			else
			{
				return BadRequest(contactFormResult.ErrorMessage);
			}
		}

		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateContactFormRequest request)
		{
			var updateResult = await contactFormService.UpdateAsync(id, request);
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
			var contactFormResult = await contactFormService.DeleteAsync(id);
			if (contactFormResult.IsSuccess)
			{
				return Ok();
			}
			else
			{
				return BadRequest(contactFormResult.ErrorMessage);
			}
		}


	}
}
