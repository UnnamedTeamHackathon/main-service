using MainService.DataAccess.Dapper.Interfaces;
using MainService.DataAccess.Dapper.Models;
using Microsoft.Extensions.Configuration;

namespace MainService.DataAccess.Models.Settings;

public class MainServiceDatabase(IConfiguration configuration) : IDapperSettings
{
    public string ConnectionString => configuration["MainServiceDatabase:ConnectionString"];
    public Provider Provider => Enum.Parse<Provider>(configuration["MainServiceDatabase:Provider"]);
}