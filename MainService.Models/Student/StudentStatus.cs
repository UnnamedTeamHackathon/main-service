using System.Text.Json.Serialization;

namespace MainService.Models.Student;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StudentStatus
{
    InProgress = 0,
    Completed = 1
}