using HrManagement.AppService.Services.ThirdPartyServices.MedicalClinic;
using HrManagement.AppService.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Security.ManagementRoles;
using HrManagement.WebApplication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.WebApplication.Pages.Company.MedicalClinic
{
    [Authorize(Roles = Roles.ACTIVE)]
    public class DeleteModel : ModalPageModel
    {
        private readonly IMedicalClinicService _medicalClinicService;

        public DeleteModel(IMedicalClinicService medicalClinicService)
        {
            _medicalClinicService = medicalClinicService;
        }

        [BindProperty]
        public MedicalClinicModel Clinic { get; set; }

        public async Task OnGetAsync(int id)
        {
            Clinic = await _medicalClinicService.GetAsync(id);
        }

        public async Task OnPostAsync()
        {
            try
            {
                var result = await _medicalClinicService.DeleteAsync((int)Clinic.Id);
                SucessResult = true;
                if (result)
                {
                    TempData[ResultsMessage.SUCCESS] = $"Departamento {Clinic.Name} removido com sucesso.";
                }
                else
                {
                    TempData[ResultsMessage.WARNING] = $"O departamento {Clinic.Name} não pode ser removido. Favor entre em contato com o suporte.";
                }

            }
            catch (Exception)
            {
                TempData[ResultsMessage.ERROR] = $"Ocorreu um erro ao excluir departamento {Clinic.Name}. Favor entre em contato com o suporte.";
            }
        }
    }
}
