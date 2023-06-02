using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementRoles
{
    public class ManagementRoles : IManagementRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManagementRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task RegisterRolesAsync()
        {
            foreach (var role in Roles.GetAll())
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task<IList<string>>GetRolesByUserAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult>RemoveRolesAsync(ApplicationUser user, string[] roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult>AddToRolesAsync(ApplicationUser user, string[] roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
