using ProductApp.DataAccess.Users;


namespace ProductApp.Services.Users;
public interface ITokenService
{
	string? GenerateToken(UserApp user);
}
