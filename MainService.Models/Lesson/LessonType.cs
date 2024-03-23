using System.Text.Json.Serialization;

namespace MainService.Models.Lesson;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LessonType
{
    Theory = 0,
    Practice = 1
}