using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess;
using ProductApp.Services.Auth;
using System;

namespace ProductApp.API.Controllers
{
    [ApiController]
	[Route("api/auth")]
	public class AuthController : Controller
	{
		private readonly ProductAppDbContext _context;
		private readonly ITokenService _tokenService;

		public AuthController(ProductAppDbContext context, ITokenService tokenService)
		{
			_context = context;
			_tokenService = tokenService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _context.Users
							.Where(u => u.Username == request.Username && !u.IsDeleted)
							.FirstOrDefaultAsync();

			if (user == null || user.Password != request.Password || user.Username != request.Username)
			{
				return Unauthorized("Kullanıcı Adı veya şifre hatalı");
			}

			var token = _tokenService.GenerateToken(user);
			    user.Token = token;
			    user.TokenCreatedDate = DateTime.Now;
			    user.UpdatedDate = DateTime.Now;

            var loginDto = new LoginResponse
            {
                Id = user.Id,
                Token = user.Token
            };

            _context.Users.Update(user);
			await _context.SaveChangesAsync();
			
			return Ok(loginDto);
		}
	}

}
