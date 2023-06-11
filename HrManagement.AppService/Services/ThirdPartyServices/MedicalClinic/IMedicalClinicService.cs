using HrManagement.AppService.ViewModels.ThirdPartyServices.Medical;

namespace HrManagement.AppService.Services.ThirdPartyServices.MedicalClinic
{
    public interface IMedicalClinicService
    {
        Task<bool> DeleteAsync(int id);
        Task<MedicalClinicModel> GetAsync(int id);
        IList<MedicalClinicModel> GetAll();
        Task<bool> CreateAsync(MedicalClinicModel model);
        Task<bool> UpdateAsync(MedicalClinicModel model);
        Task<bool> ExistMedicalClinicAsync(MedicalClinicModel model);
    }
}
