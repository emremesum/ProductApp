using ProductApp.DataAccess;
using ProductApp.DataAccess.User;
using ProductApp.DataAccess.Users;

namespace ProductApp.Services.Users;
public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserService
{
	
	public async Task<ServiceResult<UserApp>> CreateUserAsync(CreateUserRequest request)
	{
		var user = new UserApp
		{
			Username = request.Username,
			Password = request.Password,
			Role = request.Role,
			UpdatedDate = DateTime.Now
		};

		await userRepository.AddAsync(user);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult<UserApp>.Success(user);
	}

	public async Task<ServiceResult> UpdateUserAsync(int id, UpdateUserRequest request)
	{
		var user = await userRepository.GetByIdAsync(id);
		if (user == null)
		{
			return ServiceResult.Fail("User not found");
		}

		user.Username = request.Username ?? user.Username;
		user.Password = request.Password ?? user.Password;
		user.Role = request.Role ?? user.Role;
		user.UpdatedDate = DateTime.Now;

		userRepository.Update(user);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}

	public async Task<ServiceResult> DeleteUserAsync(int id)
	{
		var user = await userRepository.GetByIdAsync(id);
		if (user == null)
		{
			return ServiceResult.Fail("User not found");
		}

		user.IsDeleted = true;
		user.UpdatedDate = DateTime.Now;

		userRepository.Update(user);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}

	public async Task<ServiceResult<List<UserApp>>> GetAllAsync(string? role = null)
	{
		var users = await userRepository.GetAllAsync(role);
		return ServiceResult<List<UserApp>>.Success(users);
	}

}

