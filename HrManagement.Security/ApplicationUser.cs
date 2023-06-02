using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public bool FirstAccess { get; set; }

        public string? TempPasswordHash { get; set; }
    }
}
