using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementRoles
{
    public class ManagementRoles : IManagementRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagementRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task RegisterRolesAsync()
        {
            foreach (var role in Roles.GetAll())
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
