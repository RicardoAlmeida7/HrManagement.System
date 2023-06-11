using HrManagement.AppService.Services.CompanyServices.Department;
using HrManagement.AppService.ViewModels.Company;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.Department
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class RegisterModel : ModalPageModel
    {
        private readonly IDepartmentService _departmentService;

        public RegisterModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public DepartmentModel Department { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!_departmentService.ExistDeparment(Department.Name))
                {
                    SucessResult = true;
                    TempData[ResultsMessage.SUCCESS] = $"Departamento {Department.Name} cadastrado com sucesso.";
                    _departmentService.CreateAsync(Department).Wait();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Departamento {Department.Name} já foi registrado.");
                }
            }
        }
    }
}
