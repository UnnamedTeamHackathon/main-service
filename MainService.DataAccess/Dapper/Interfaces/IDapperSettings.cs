using MainService.DataAccess.Dapper.Models;

namespace MainService.DataAccess.Dapper.Interfaces;

public interface IDapperSettings
{
    string ConnectionString { get; }
    Provider Provider { get; }
}