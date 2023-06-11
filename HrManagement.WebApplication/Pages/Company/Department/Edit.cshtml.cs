using HrManagement.AppService.Services.CompanyServices.Department;
using HrManagement.AppService.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Department
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class EditModel : ModalPageModel
    {
        private readonly IDepartmentService _departmentService;

        public EditModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public DepartmentModel Department { get; set; }

        public async Task OnGetAsync(int id)
        {
            Department = await _departmentService.GetAsync(id);
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!_departmentService.ExistDeparment(Department.Name))
                {
                    SucessResult = true;
                    var result = await _departmentService.UpdateAsync(Department);
                    if (result)
                    {
                        TempData[ResultsMessage.SUCCESS] = $"Departamento {Department.Name} atualizado com sucesso.";
                    }
                    else
                    {
                        TempData[ResultsMessage.WARNING] = $"Departamento {Department.Name} atualizado não pode ser atualizado.";
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Departamento {Department.Name} já foi registrado.");
                }
            }
        }
    }
}
