using ProductApp.DataAccess.Users;


namespace ProductApp.Services.Auth;
public interface ITokenService
{
    string? GenerateToken(UserApp user);
}
