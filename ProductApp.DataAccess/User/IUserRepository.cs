using ProductApp.DataAccess.Users;

namespace ProductApp.DataAccess.User;

public interface IUserRepository :IGenericRepository<UserApp> 
{
	Task<List<UserApp>> GetAllAsync(string? role);

}
