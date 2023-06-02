using HrManagement.AppService.AutoMapper.UserService;
using HrManagement.AppService.ViewModels.UsersViewModel;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HrManagement.WebApplication.Pages.Users
{
    [Authorize(Roles = Roles.ACTIVE)]
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public class EditModel : ModalPageModel
    {
        [BindProperty]
        public UserPageModel UserPageModel { get; set; }

        [BindProperty]
        public IList<string> SelectedRoles { get; set; }

        private readonly IManagementUsers _managementUsers;
        private readonly IManagementRoles _managementRoles;
        private readonly IUserService _userService;

        public EditModel(IManagementUsers managementUsers, IManagementRoles managementRoles, IUserService userService)
        {
            _managementUsers = managementUsers;
            _managementRoles = managementRoles;
            SucessResult = false;
            _userService = userService;
        }

        public async Task OnGetAsync(string id)
        {
            var user = await _managementUsers.FindByIdAsync(id);
            var roles = await _managementRoles.GetRolesByUserAsync(user);
            UserPageModel = _userService.GetUserPageModelFromApplicationUser(user, roles.ToArray());
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _managementUsers.FindByIdAsync(UserPageModel.Id);
            IList<string> roles = await _managementRoles.GetRolesByUserAsync(user);
            if (ModelState.IsValid)
            {
                user.Email = UserPageModel.Email;
                user.FullName = UserPageModel.FullName;
                user.UserName = UserPageModel.UserName;

                var result = await _managementUsers.UpdateUserAsync(user);
                if (result.Succeeded)
                {

                    result = await _managementRoles.RemoveRolesAsync(user, roles.ToArray());
                    if (result.Succeeded)
                    {
                        if (SelectedRoles.Count > 0)
                        {
                            result = await _managementRoles.AddToRolesAsync(user, SelectedRoles.ToArray());
                        }
                        if (result.Succeeded)
                        {
                            this.SucessResult = true;
                            TempData[ResultsMessage.SUCCESS] = $"Usuário {user.FullName} atualizado com sucesso.";
                            return Page();
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            UserPageModel = _userService.GetUserPageModelFromApplicationUser(user, roles.ToArray());
            return Page();
        }
    }
}
