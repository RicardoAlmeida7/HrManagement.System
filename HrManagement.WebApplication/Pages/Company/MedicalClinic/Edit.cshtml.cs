using HrManagement.Domain.Services.ThirdPartyServices.Medical;
using HrManagement.Domain.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.MedicalClinic
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class EditModel : ModalPageModel
    {
        private readonly IMedicalClinicService _medicalClinicService;

        public EditModel(IMedicalClinicService medicalClinicService)
        {
            _medicalClinicService = medicalClinicService;
        }

        [BindProperty]
        public MedicalClinicModel MedicalClinic { get; set; }

        public async Task OnGetAsync(int id)
        {
            MedicalClinic = await _medicalClinicService.GetAsync(id);
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (_medicalClinicService.NameAvailableForUseAsync(MedicalClinic).Result)
                {
                    SucessResult = true;
                    var result = await _medicalClinicService.UpdateAsync(MedicalClinic);
                    if (result)
                    {
                        TempData[ResultsMessage.SUCCESS] = $"Departamento {MedicalClinic.Name} atualizado com sucesso.";
                    }
                    else
                    {
                        TempData[ResultsMessage.WARNING] = $"Departamento {MedicalClinic.Name} atualizado não pode ser atualizado.";
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Departamento {MedicalClinic.Name} já foi registrado.");
                }
            }
        }
    }
}
