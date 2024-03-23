namespace MainService.DataAccess.Models;

public class DbCourse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public Guid TypeId { get; set; }
}