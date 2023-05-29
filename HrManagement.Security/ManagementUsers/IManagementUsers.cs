using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementUsers
{
    public interface IManagementUsers
    {
        IList<ApplicationUser> GetAll();

        Task UnblockUsersAsync(string userId);

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string[] roles);

        Task<bool> CreateAdminAsync(string adminName, string fullName, string email, string password, string tempPasswordHash);

        Task<ApplicationUser?> FindByEmailAsync(string email);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);

        Task<ApplicationUser?> FindByIdAsync(string id);

        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
    }
}
