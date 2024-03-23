using System.Text.Json.Serialization;

namespace MainService.Models.Course;

public class UpdateCourseRequest
{
    [JsonIgnore] public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CourseDifficulty? Difficulty { get; set; }
    public Guid? TypeId { get; set; }
}