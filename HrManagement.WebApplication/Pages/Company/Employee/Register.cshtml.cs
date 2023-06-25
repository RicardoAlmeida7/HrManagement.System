using HrManagement.Domain.Services.Employee;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Employee
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class RegisterModel : ModalPageModel
    {
        private readonly IEmployeeService _employeeService;

        public RegisterModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                SucessResult = true;
                TempData[ResultsMessage.SUCCESS] = $"Colaborador {Employee.Name} cadastrado com sucesso.";
                _employeeService.CreateAsync(Employee).Wait();
            }
        }
    }
}
