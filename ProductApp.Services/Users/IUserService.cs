using ProductApp.DataAccess.Users;

namespace ProductApp.Services.Users;

public interface IUserService
{
    Task<ServiceResult<UserApp>> CreateUserAsync(CreateUserRequest request);
    Task<ServiceResult> UpdateUserAsync(int id, UpdateUserRequest request);
    Task<ServiceResult> DeleteUserAsync(int id);
	Task<ServiceResult<List<UserApp>>> GetAllAsync(string? role);
}
