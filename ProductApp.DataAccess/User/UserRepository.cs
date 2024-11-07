using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess.Products;
using ProductApp.DataAccess.Users;

namespace ProductApp.DataAccess.User;

public class UserRepository(ProductAppDbContext context) : GenericRepository<UserApp>(context), IUserRepository
{
	public async Task<List<UserApp>> GetAllAsync(string? role = null)
	{
		IQueryable<UserApp> query = GetAll();

		if (!string.IsNullOrEmpty(role))
		{
			query = query.Where(u => u.Role == role);
		}

		return await query.ToListAsync();
	}

}
