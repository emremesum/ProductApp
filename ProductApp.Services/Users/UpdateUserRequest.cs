namespace ProductApp.Services.Users;
public class UpdateUserRequest
{
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Role { get; set; }
}