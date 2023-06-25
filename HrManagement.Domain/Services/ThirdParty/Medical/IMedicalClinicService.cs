using HrManagement.Domain.ViewModels.ThirdPartyServices.Medical;

namespace HrManagement.Domain.Services.ThirdPartyServices.Medical
{
    public interface IMedicalClinicService
    {
        Task<bool> DeleteAsync(int id);
        Task<MedicalClinicModel> GetAsync(int id);
        IList<MedicalClinicModel> GetAll();
        Task<bool> CreateAsync(MedicalClinicModel model);
        Task<bool> UpdateAsync(MedicalClinicModel model);
        Task<bool> NameAvailableForUseAsync(MedicalClinicModel model);
    }
}
