using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementUsers
{
    public class ManagementUsers : IManagementUsers
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManagementUsers(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IList<ApplicationUser> GetAll() => _userManager.Users.ToList();

        public async Task UnblockUsersAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }
            await _userManager.SetLockoutEndDateAsync(user, DateTime.Now);
            await _userManager.ResetAccessFailedCountAsync(user);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string[] roles)
        {
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, roles);
            }

            return result;
        }

        public async Task CreateAdminAsync(string adminName, string fullName, string email, string password, string tempPasswordHash)
        {
            var admin = await _userManager.FindByNameAsync(adminName);

            if (admin is null)
            {
                var user = new ApplicationUser()
                {
                    UserName = adminName,
                    FullName = fullName,
                    Email = email,
                    FirstAccess = true,
                    TempPasswordHash = tempPasswordHash
                };

                _userManager.CreateAsync(user, password).Wait();
                _userManager.AddToRoleAsync(user, Roles.ACTIVE).Wait();
                _userManager.AddToRoleAsync(user, Roles.ADMINISTRATOR).Wait();
            }
        }
    }
}
