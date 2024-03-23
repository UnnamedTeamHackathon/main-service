namespace MainService.DataAccess.Models;

public class DbStudent
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public int Status { get; set; }
}