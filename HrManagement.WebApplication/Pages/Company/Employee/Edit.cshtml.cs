using HrManagement.Domain.Services.Employee;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Employee
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class EditModel : ModalPageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }

        public async Task OnGet(int id)
        {
            Employee = await _employeeService.GetAsync(id);
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                SucessResult = true;
                TempData[ResultsMessage.SUCCESS] = $"Colaborador {Employee.Name} atualizado com sucesso.";
                await _employeeService.UpdateAsync(Employee);
            }
        }
    }
}
