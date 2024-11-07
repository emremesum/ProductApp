namespace ProductApp.DataAccess.Users;

public class UserApp
{
	public int Id { get; set; }
	public string Username { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string? Token { get; set; }
	public DateTime? TokenCreatedDate { get; set; }
	public DateTime UpdatedDate { get; set; }
	public bool IsDeleted { get; set; } = false;
	public string Role { get; set; } = "Customer"; 
}

