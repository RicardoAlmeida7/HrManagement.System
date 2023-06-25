using AutoMapper;
using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Repositories.Company;
using HrManagement.Domain.Services.Department;
using HrManagement.Domain.Utils;
using HrManagement.Domain.ViewModels.Company;

namespace HrManagement.AppService.Services.CompanyServices.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _service;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(DepartmentModel model)
        {
            var entity = _mapper.Map<DepartmentModel, DepartmentEntity>(model);
            return await _service.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _service.ReadByIdAsync(id);
            return await _service.DeleteAsync(entity);
        }

        public bool ExistDeparment(string name)
        {
            return _service.ReadAll().Any(e => StringUtils.Compare(e.Name, name));
        }

        public IList<DepartmentModel> GetAll()
        {
            var departments = new List<DepartmentModel>();
            var entities = _service.ReadAll();
            foreach (var entity in entities)
            {
                departments.Add(_mapper.Map<DepartmentEntity, DepartmentModel>(entity));
            }
            return departments;
        }

        public async Task<DepartmentModel> GetAsync(int id)
        {
            var entity = await _service.ReadByIdAsync(id);
            return _mapper.Map<DepartmentEntity, DepartmentModel>(entity);
        }

        public async Task<bool> UpdateAsync(DepartmentModel model)
        {
            var entity = _mapper.Map<DepartmentModel, DepartmentEntity>(model);
            return await _service.UpdateAsync(entity);
        }
    }
}
