using HrManagement.AppService.AutoMapper.UserService;
using HrManagement.AppService.ViewModels.UsersViewModel;
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
        private readonly IUserService _userService;

        public RegisterModel(IManagementUsers managementUsers, RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            _managementUsers = managementUsers;
            UserPageModel = new UserPageModel(roleManager);
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByUserPageModel(UserPageModel);
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
            return Page();
        }
    }
}
