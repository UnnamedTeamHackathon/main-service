using System.Text.Json.Serialization;

namespace MainService.Models.User;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Country
{
    Russia = 0,
    USA = 1,
    UK = 2,
    Germany = 3,
    France = 4
}