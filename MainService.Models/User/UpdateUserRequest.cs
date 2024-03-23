using System.Text.Json.Serialization;

namespace MainService.Models.User;

public class UpdateUserRequest
{
    [JsonIgnore] public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public DateTime? Birthday { get; set; }
    public Guid? PhotoId { get; set; }
    public Country Country { get; set; }
}