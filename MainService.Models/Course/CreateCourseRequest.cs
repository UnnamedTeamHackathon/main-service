namespace MainService.Models.Course;

public class CreateCourseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CourseDifficulty Difficulty { get; set; }
    public Guid TypeId { get; set; }
}