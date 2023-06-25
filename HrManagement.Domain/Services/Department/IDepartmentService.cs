using HrManagement.Domain.ViewModels.Company;

namespace HrManagement.Domain.Services.Department
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
