using HrManagement.AppService.ViewModels.Company;

namespace HrManagement.AppService.Services.CompanyServices.Department
{
    public interface IDepartmentService
    {
        Task<bool> DeleteAsync(int id);
        Task<DepartmentModel> GetAsync(int id);
        IList<DepartmentModel> GetAll();
        Task<bool> CreateAsync(DepartmentModel model);
        Task<bool> UpdateAsync(DepartmentModel model);
        bool ExistDeparment(string name);
    }
}
