namespace MainService.DataAccess.Models;

public class DbLesson
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public string Text { get; set; }
    public Guid? VideoId { get; set; }
    public Guid? TaskId { get; set; }
    public int Type { get; set; }
    public int Order { get; set; }
}