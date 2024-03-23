using MainService.DataAccess.Models;
using MainService.Models.User;

namespace MainService.Services.Mappers;

public static class UserMapper
{
    public static User MapToDomain(this DbUser source)
    {
        return source == null
            ? default
            : new User
            {
                Id = source.Id,
                Role = (Role)source.Role,
                Email = source.Email,
                Username = source.Username,
                Name = source.Name,
                Surname = source.Surname,
                Patronymic = source.Patronymic,
                Birthday = source.Birthday,
                PhotoId = source.PhotoId,
                Country = (Country)source.Country
            };
    }

    public static List<User> MapToDomain(this List<DbUser> source)
    {
        return source == null ? [] : source.Select(x => x.MapToDomain()).ToList();
    }

    public static DbUser MapToDb(this User source)
    {
        return source == null
            ? default
            : new DbUser
            {
                Id = source.Id,
                Role = (int)source.Role,
                Email = source.Email,
                Username = source.Username,
                Name = source.Name,
                Surname = source.Surname,
                Patronymic = source.Patronymic,
                Birthday = source.Birthday,
                PhotoId = source.PhotoId,
                Country = (int)source.Country
            };
    }

    public static DbUser MapToDb(this UpdateUserRequest source)
    {
        return source == null
            ? default
            : new DbUser
            {
                Id = source.Id,
                Email = source.Email,
                Username = source.Username,
                Name = source.Name,
                Surname = source.Surname,
                Patronymic = source.Patronymic,
                Birthday = source.Birthday,
                PhotoId = source.PhotoId,
                Country = (int)source.Country
            };
    }
}