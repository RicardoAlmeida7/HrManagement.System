using HrManagement.AppService.Services.ThirdPartyServices.MedicalClinic;
using HrManagement.AppService.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.MedicalClinic
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class RegisterModel : ModalPageModel
    {
        private readonly IMedicalClinicService _medicalClinicService;

        public RegisterModel(IMedicalClinicService medicalClinicService)
        {
            _medicalClinicService = medicalClinicService;
        }

        [BindProperty]
        public MedicalClinicModel MedicalClinic { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!_medicalClinicService.ExistMedicalClinicAsync(MedicalClinic).Result)
                {
                    SucessResult = true;
                    TempData[ResultsMessage.SUCCESS] = $"Clinica médica {MedicalClinic.Name} cadastrada com sucesso.";
                    _medicalClinicService.CreateAsync(MedicalClinic).Wait();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Clinica médica {MedicalClinic.Name} já foi registrada.");
                }
            }
        }
    }
}
