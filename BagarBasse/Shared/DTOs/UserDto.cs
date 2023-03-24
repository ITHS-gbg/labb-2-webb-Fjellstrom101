using BagarBasse.Shared.Models;

namespace BagarBasse.Shared.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }

    public UserInfo UserInfo { get; set; }

    public DateTime DateCreated { get; set; }

    public string Role { get; set; } 
}