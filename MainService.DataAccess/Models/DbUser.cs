namespace MainService.DataAccess.Models;

public class DbUser
{
    public Guid Id { get; set; }
    public int Role { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiredAfter { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public DateTime? Birthday { get; set; }
    public Guid? PhotoId { get; set; }
    public int Country { get; set; }
}