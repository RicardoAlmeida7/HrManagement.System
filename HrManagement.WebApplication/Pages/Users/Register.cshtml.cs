using HrManagement.AppService.ViewModels.UsersViewModel;
using HrManagement.Security;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Users
{
    [Authorize(Roles = Roles.ACTIVE)]
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public class RegisterModel : ModalPageModel
    {
        [BindProperty]
        public UserPageModel UserPageModel { get; set; }

        [BindProperty]
        public IList<string> SelectedRoles { get; set; }

        private readonly IManagementUsers _managementUsers;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(IManagementUsers managementUsers, RoleManager<IdentityRole> roleManager)
        {
            _managementUsers = managementUsers;
            _roleManager = roleManager;
        }

        public void OnGet()
        {
            UserPageModel = new UserPageModel(_roleManager);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = UserPageModel.UserName,
                    FirstAccess = true,
                    Email = UserPageModel.Email,
                    FullName = UserPageModel.FullName
                };
                var result = await _managementUsers.CreateUserAsync(user, SelectedRoles.ToArray());
                if (result.Succeeded)
                {
                    this.SucessResult = true;
                    TempData[ResultsMessage.SUCCESS] = $"Usuário {user.FullName} cadastrado com sucesso.";
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            UserPageModel = new UserPageModel(_roleManager);
            return Page();
        }
    }
}
