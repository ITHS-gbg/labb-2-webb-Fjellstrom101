using System.ComponentModel.DataAnnotations;

namespace BagarBasse.Shared.Models;

public class UserInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [Required, StringLength(maximumLength:100, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;
    [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
    public string Street { get; set; } = string.Empty;
    [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
    public string City { get; set; } = string.Empty;
    [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
    public string PostalCode { get; set; } = string.Empty;
    [Required, Phone, StringLength(maximumLength:100, MinimumLength = 6)]
    public string PhoneNumber { get; set; } = string.Empty;

}