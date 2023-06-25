using HrManagement.AppService.AutoMapper.UserService;
using HrManagement.Domain.ViewModels.UsersViewModel;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Users
{
    [Authorize(Roles = Roles.ACTIVE)]
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public class DeleteModel : ModalPageModel
    {
        [BindProperty]
        public UserPageModel UserPageModel { get; set; }

        private readonly IManagementUsers _managementUsers;
        private readonly IUserService _userService;

        public DeleteModel(IManagementUsers managementUsers, IUserService userService)
        {
            _managementUsers = managementUsers;
            _userService = userService;
        }

        public async Task OnGetAsync(string id)
        {
            var user = await _managementUsers.FindByIdAsync(id);
            UserPageModel = _userService.GetUserPageModelFromApplicationUser(user);
        }

        public async Task OnPostAsync()
        {
            try
            {
                var user = await _managementUsers.FindByIdAsync(UserPageModel.Id);
                var result = await _managementUsers.DeleteUserAsync(user);
                SucessResult = true;
                if (result.Succeeded)
                {
                    TempData[ResultsMessage.SUCCESS] = $"Usuário {user.FullName} removido com sucesso.";
                }
                else
                {
                    TempData[ResultsMessage.WARNING] = $"O usuário {user.FullName} não pode ser removido. Favor entre em contato com o suporte.";
                }
            }
            catch (Exception)
            {
                TempData[ResultsMessage.ERROR] = $"Ocorreu um erro ao excluir o usuário. Favor entre em contato com o suporte.";
            }
        }
    }
}
