using System.Text.Json.Serialization;

namespace MainService.Models.User;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    User = 1,
    Admin = 2
}