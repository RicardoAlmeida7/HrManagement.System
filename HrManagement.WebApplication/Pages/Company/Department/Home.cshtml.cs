using HrManagement.AppService.Services.CompanyServices.Department;
using HrManagement.AppService.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace HrManagement.WebApplication.Pages.Company.Department
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class HomeModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public HomeModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        private const int PAGE_SIZE = 7;
        private const int FIRST_PAGE = 1;

        [BindProperty]
        public IPagedList<DepartmentModel> Departments { get; set; }

        public void OnGet(int? pageNumber, string searchString)
        {
            var users = _departmentService.GetAll().OrderBy(u => u.Name).ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(x => x.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            Departments = users.ToPagedList(pageNumber ?? FIRST_PAGE, PAGE_SIZE);
        }
    }
}
