using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Dapper.Models;
using MainService.DataAccess.Models;
using MainService.DataAccess.Repositories.Interfaces;
using MainService.DataAccess.Repositories.Scripts;

namespace MainService.DataAccess.Repositories;

public class UserRepository(IDapperContext<IDapperSettings> dapperContext) : IUserRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<bool> IsUserExistsById(Guid id)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsById, new { id }));
    }
    
    public async Task<bool> IsUserExistsByEmail(string email)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsByEmail, new { email }));
    }

    public async Task<bool> IsUserExistsByUsername(string username)
    {
        return await dapperContext.FirstOrDefault<bool>(new QueryObject(Sql.IsUserExistsByUsername, new { username }));
    }

    public async Task<Guid> CreateUser(DbUser user)
    {
        return await dapperContext.CommandWithResponse<Guid>(new QueryObject(Sql.CreateUser, user));
    }

    public async Task<DbUser> GetUser(Guid id)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserById, new { id }));
    }

    public async Task<DbUser> GetUser(string email, string passwordHash)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserByEmailAndPassword, new { email, passwordHash }));
    }

    public async Task<DbUser> GetUserByRefreshToken(string refreshToken)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(Sql.GetUserByRefreshToken, new { refreshToken }));
    }

    public async Task<List<DbUser>> GetUsers()
    {
        return await dapperContext.ListOrEmpty<DbUser>(new QueryObject(Sql.GetUsers));
    }

    public async Task UpdateRefreshToken(Guid id, string refreshToken, DateTime refreshTokenExpiredAfter)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateRefreshToken, new { id, refreshToken, refreshTokenExpiredAfter }));
    }

    public async Task UpdateUser(DbUser user)
    {
        await dapperContext.Command(new QueryObject(Sql.UpdateUser, user));
    }

    public async Task DeleteUser(Guid id)
    {
        await dapperContext.Command(new QueryObject(Sql.DeleteUser, new { id }));
    }

    public async Task ChangePassword(Guid id, string passwordHash)
    {
        await dapperContext.Command(new QueryObject(Sql.ChangePassword, new { id, passwordHash }));
    }

    public async Task ChangeRole(Guid id, int role)
    {
        await dapperContext.Command(new QueryObject(Sql.ChangeRole, new { id, role }));
    }
}