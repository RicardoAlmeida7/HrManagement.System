using HrManagement.AppService.ViewModels.Company;

namespace HrManagement.AppService.Services.CompanyServices.Employee
{
    public interface IEmployeeService
    {
        Task<bool> DeleteAsync(int id);
        Task<EmployeeModel> GetAsync(int id);
        IList<EmployeeModel> GetAll();
        Task<bool> CreateAsync(EmployeeModel model);
        Task<bool> UpdateAsync(EmployeeModel model);
    }
}
