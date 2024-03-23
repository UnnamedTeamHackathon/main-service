using MainService.Models.User;

namespace MainService.Services.Interfaces;

public interface IUserService
{ 
    Task<User> GetUser(Guid id);
    Task<List<User>> GetUsers();
    Task UpdateUser(UpdateUserRequest request);
    Task DeleteUser(Guid id);
    Task ChangePassword(ChangePasswordRequest request);
    Task ChangeRole(Guid id, Role role);
}