using MainService.Common;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.Models.User;
using MainService.Services.Exceptions;
using MainService.Services.Interfaces;
using MainService.Services.Mappers;

namespace MainService.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> GetUser(Guid id)
    {
        var user = await userRepository.GetUser(id);
        if (user == null)
        {
            throw new UserNotFoundException(id);
        }

        return user.MapToDomain();
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await userRepository.GetUsers();

        return users.MapToDomain();
    }

    public async Task UpdateUser(UpdateUserRequest request)
    {
        if (!await userRepository.IsUserExistsById(request.Id))
        {
            throw new UserNotFoundException(request.Id);
        }

        if (!string.IsNullOrEmpty(request.Email) && await userRepository.IsUserExistsByEmail(request.Email))
        {
            throw new EmailAlreadyTakenException(request.Email);
        }
        
        if (!string.IsNullOrEmpty(request.Username) && await userRepository.IsUserExistsByUsername(request.Username))
        {
            throw new UsernameAlreadyTakenException(request.Username);
        }

        await userRepository.UpdateUser(request.MapToDb());
    }

    public async Task DeleteUser(Guid id)
    {
        if (!await userRepository.IsUserExistsById(id))
        {
            throw new UserNotFoundException(id);
        }

        await userRepository.DeleteUser(id);
    }

    public async Task ChangePassword(ChangePasswordRequest request)
    {
        var user = await userRepository.GetUser(request.Email, Hash.GetHash(request.OldPassword));
        if (user == null)
        {
            throw new BadCredentialsException();
        }

        await userRepository.ChangePassword(user.Id, Hash.GetHash(request.NewPassword));
    }

    public async Task ChangeRole(Guid id, Role role)
    {
        if (!await userRepository.IsUserExistsById(id))
        {
            throw new UserNotFoundException(id);
        }

        await userRepository.ChangeRole(id, (int)role);
    }
}