using System.Text.Json.Serialization;

namespace MainService.Models.Course;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CourseDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}