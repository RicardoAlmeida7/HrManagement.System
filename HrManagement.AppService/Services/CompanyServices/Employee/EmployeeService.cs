using AutoMapper;
using HrManagement.AppService.ViewModels.Company;
using HrManagement.Data.Repositories.CompanyRepositories;
using HrManagement.Domain.Entities.Company;

namespace HrManagement.AppService.Services.CompanyServices.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(EmployeeModel model)
        {
            var entity = _mapper.Map<EmployeeModel, EmployeeEntity>(model);
            return await _employeeRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _employeeRepository.ReadByIdAsync(id);
            return await _employeeRepository.DeleteAsync(entity);
        }

        public IList<EmployeeModel> GetAll()
        {
            var list = new List<EmployeeModel>();
            var entities =  _employeeRepository.ReadAll();
            foreach (var entity in entities)
            {
                list.Add(_mapper.Map<EmployeeEntity, EmployeeModel>(entity));
            }
            return list;
        }

        public async Task<EmployeeModel> GetAsync(int id)
        {
            var entity = await  _employeeRepository.ReadByIdAsync(id);
            return _mapper.Map<EmployeeEntity, EmployeeModel>(entity);
        }

        public async Task<bool> UpdateAsync(EmployeeModel model)
        {
            var entity = _mapper.Map<EmployeeModel, EmployeeEntity>(model);
            return await _employeeRepository.UpdateAsync(entity);
        }
    }
}
