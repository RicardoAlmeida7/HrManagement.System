using HrManagement.Domain.Services.Employee;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Employee
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class DeleteModel : ModalPageModel
    {
        private readonly IEmployeeService _employeeService;

        public DeleteModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeModel Employee { get; set; }

        public async Task OnGetAsync(int id)
        {
            Employee = await _employeeService.GetAsync(id);
        }

        public async Task OnPostAsync()
        {
            try
            {
                var result = await _employeeService.DeleteAsync((int)Employee.Id);
                SucessResult = true;
                if (result)
                {
                    TempData[ResultsMessage.SUCCESS] = $"Colaborador {Employee.Name} removido com sucesso.";
                }
                else
                {
                    TempData[ResultsMessage.WARNING] = $"O colaborador {Employee.Name} não pode ser removido. Favor entre em contato com o suporte.";
                }
            }
            catch (Exception)
            {
                TempData[ResultsMessage.ERROR] = $"Ocorreu um erro ao excluir colaborador {Employee.Name}. Favor entre em contato com o suporte.";
            }
        }
    }
}
