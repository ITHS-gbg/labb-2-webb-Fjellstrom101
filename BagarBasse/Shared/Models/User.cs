namespace BagarBasse.Shared.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public UserInfo UserInfo { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public string Role { get; set; } = "Customer";

}