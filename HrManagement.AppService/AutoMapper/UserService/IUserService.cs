using HrManagement.Domain.ViewModels.UsersViewModel;
using HrManagement.Security;

namespace HrManagement.AppService.AutoMapper.UserService
{
    public interface IUserService
    {
        UserPageModel GetUserPageModelFromApplicationUser(ApplicationUser user, string[] roles = null);

        ApplicationUser GetByUserPageModel(UserPageModel user);
    }
}
