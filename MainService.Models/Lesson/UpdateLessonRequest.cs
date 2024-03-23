using System.Text.Json.Serialization;

namespace MainService.Models.Lesson;

public class UpdateLessonRequest
{
    [JsonIgnore] public Guid Id { get; set; }
    public Guid? ModuleId { get; set; }
    public string Text { get; set; }
    public Guid? VideoId { get; set; }
    public Guid? TaskId { get; set; }
    public LessonType? Type { get; set; }
    public int? Order { get; set; }
}