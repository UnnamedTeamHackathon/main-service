using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Models;

namespace MainService.DataAccess.Repositories.Interfaces;

public interface IUserRepository
{
    ITransaction BeginTransaction();
    Task<bool> IsUserExistsById(Guid id);
    Task<bool> IsUserExistsByEmail(string email);
    Task<bool> IsUserExistsByUsername(string username);
    Task<Guid> CreateUser(DbUser user);
    Task<DbUser> GetUser(Guid id);
    Task<DbUser> GetUser(string email, string passwordHash);
    Task<DbUser> GetUserByRefreshToken(string refreshToken);
    Task<List<DbUser>> GetUsers();
    Task UpdateRefreshToken(Guid id, string refreshToken, DateTime refreshTokenExpiredAfter);
    Task UpdateUser(DbUser user);
    Task DeleteUser(Guid id);
    Task ChangePassword(Guid id, string passwordHash);
    Task ChangeRole(Guid id, int role);
}