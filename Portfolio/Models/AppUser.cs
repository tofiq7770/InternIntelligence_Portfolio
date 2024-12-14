using Microsoft.AspNetCore.Identity;

namespace Portfolio.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
