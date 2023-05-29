using HrManagement.EmailService;
using HrManagement.EmailService.Templates;
using HrManagement.Security.Cryptography;
using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.ManagementUsers
{
    public class ManagementUsers : IManagementUsers
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public ManagementUsers(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
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

        public async Task<ApplicationUser?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser?> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string[] roles)
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var tempPassword = Encrypt.GenerateRandomString(8);
                user.TempPasswordHash = Encrypt.GenerateSHA256Hash(tempPassword);
                result = await _userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded)
                {
                    _emailService.SendEmail(
                        user.Email,
                        Subject.ACCESS_CREDENTIALS,
                        AccessCredentialsTemplate.Build(user.UserName, tempPassword));
                }
            };
            return result;
        }

        public async Task<bool> CreateAdminAsync(string adminName, string fullName, string email, string password, string tempPasswordHash)
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

                var result = await _userManager.CreateAsync(user, password);
                _userManager.AddToRoleAsync(user, Roles.ACTIVE).Wait();
                _userManager.AddToRoleAsync(user, Roles.ADMINISTRATOR).Wait();
                return result.Succeeded;
            }
            return false;
        }
    }
}
