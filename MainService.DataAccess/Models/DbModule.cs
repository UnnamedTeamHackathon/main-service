namespace MainService.DataAccess.Models;

public class DbModule
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
}