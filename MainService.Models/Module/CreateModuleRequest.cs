using System.Text.Json.Serialization;

namespace MainService.Models.Module;

public class CreateModuleRequest
{
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    [JsonIgnore] public int Order { get; set; }
}