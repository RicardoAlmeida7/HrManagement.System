using HrManagement.Domain.Services.Department;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Department
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class DeleteModel : ModalPageModel
    {
        private readonly IDepartmentService _departmentService;

        public DeleteModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public DepartmentModel Department { get; set; }

        public async Task OnGetAsync(int id)
        {
            Department = await _departmentService.GetAsync(id);
        }

        public async Task OnPostAsync()
        {
            SucessResult = true;
            try
            {
                var result = await _departmentService.DeleteAsync((int)Department.Id);
                if (result)
                {
                    TempData[ResultsMessage.SUCCESS] = $"Departamento {Department.Name} removido com sucesso.";
                }
                else
                {
                    TempData[ResultsMessage.WARNING] = $"O departamento {Department.Name} não pode ser removido. Favor entre em contato com o suporte.";
                }

            }
            catch (Exception)
            {
                TempData[ResultsMessage.ERROR] = $"Ocorreu um erro ao excluir departamento {Department.Name}. Favor entre em contato com o suporte.";
            }
        }
    }
}
