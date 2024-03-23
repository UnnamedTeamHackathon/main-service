using System.Text.Json.Serialization;

namespace MainService.Models.Lesson;

public class CreateLessonRequest
{
    public Guid ModuleId { get; set; }
    public string Text { get; set; }
    public Guid? VideoId { get; set; }
    public Guid? TaskId { get; set; }
    public LessonType Type { get; set; }
    [JsonIgnore] public int Order { get; set; }
}