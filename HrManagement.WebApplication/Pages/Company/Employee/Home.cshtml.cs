using HrManagement.Domain.Services.Employee;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace HrManagement.WebApplication.Pages.Company.Employee
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class HomeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public HomeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private const int PAGE_SIZE = 7;
        private const int FIRST_PAGE = 1;

        [BindProperty]
        public IPagedList<EmployeeModel> Employees { get; set; }

        public void OnGet(int? pageNumber, string searchString)
        {
            var users = _employeeService.GetAll().OrderBy(u => u.Name).ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(x => x.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            Employees = users.ToPagedList(pageNumber ?? FIRST_PAGE, PAGE_SIZE);
        }
    }
}
