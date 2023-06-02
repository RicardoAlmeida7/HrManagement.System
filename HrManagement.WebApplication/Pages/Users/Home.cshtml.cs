using HrManagement.Security;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace HrManagement.WebApplication.Pages.Users
{
    [Authorize(Roles =Roles.ACTIVE)]
    [Authorize(Roles =Roles.ADMINISTRATOR)]
    public class HomeModel : PageModel
    {
        private readonly IManagementUsers _managementUser;
        private const int PAGE_SIZE = 7;
        private const int FIRST_PAGE = 1;

        [BindProperty]
        public IPagedList<ApplicationUser> Users { get; set; }

        public HomeModel(IManagementUsers managementUsers)
        {
            _managementUser = managementUsers;
        }

        public void OnGet(int? pageNumber, string searchString)
        {
            var users = _managementUser.GetAll().OrderBy(u => u.FullName).ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(x => x.FullName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            Users = users.ToPagedList(pageNumber ?? FIRST_PAGE, PAGE_SIZE);
        }
    }
}
