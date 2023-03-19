using Microsoft.AspNetCore.Identity;

namespace BagarBasse.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? FirstName { get; set; }
        [PersonalData]
        public string? LastName { get; set; }

        [PersonalData]
        public string? Address { get; set; }
        [PersonalData]
        public string? PostalCode { get; set; }
        [PersonalData]
        public string? City { get; set; }

    }
}