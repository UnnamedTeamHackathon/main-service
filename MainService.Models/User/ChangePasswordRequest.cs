using System.Text.Json.Serialization;

namespace MainService.Models.User;

public class ChangePasswordRequest
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    [JsonIgnore] public string Email { get; set; }
}