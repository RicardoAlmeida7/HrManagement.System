using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementRoles
{
    public interface IManagementRoles
    {
        Task RegisterRolesAsync();

        Task<IList<string>> GetRolesByUserAsync(ApplicationUser user);

        Task<IdentityResult> RemoveRolesAsync(ApplicationUser user, string[] roles);

        Task<IdentityResult> AddToRolesAsync(ApplicationUser user, string[] roles);
    }
}
