namespace MainService.Models.Student;

public class Student
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public StudentStatus Status { get; set; }
}