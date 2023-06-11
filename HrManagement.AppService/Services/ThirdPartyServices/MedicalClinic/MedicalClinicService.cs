using AutoMapper;
using HrManagement.AppService.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Data.Repositories.ThirdPartyServicesRepository.Medical;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using HrManagement.Domain.Utils;
using System.Xml.Linq;

namespace HrManagement.AppService.Services.ThirdPartyServices.MedicalClinic
{
    public class MedicalClinicService : IMedicalClinicService
    {
        private readonly IMedicalClinicRepository _service;
        private readonly IMapper _mapper;

        public MedicalClinicService(IMedicalClinicRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(MedicalClinicModel model)
        {
            var entity = _mapper.Map<MedicalClinicModel, MedicalClinicEntity>(model);
            return await _service.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _service.ReadByIdAsync(id);
            return await _service.DeleteAsync(entity);
        }

        public async Task<bool> ExistMedicalClinicAsync(MedicalClinicModel model)
        {
            var entities = _service.ReadAll();
            foreach (var entity in entities)
            {
                if (StringUtils.FormantStringToCompare(entity.Name).Equals(StringUtils.FormantStringToCompare(model.Name)))
                {
                    return true;
                }
            }
            return false;
        }

        public IList<MedicalClinicModel> GetAll()
        {
            var departments = new List<MedicalClinicModel>();
            var entities = _service.ReadAll();
            foreach (var entity in entities)
            {
                departments.Add(_mapper.Map<MedicalClinicEntity, MedicalClinicModel>(entity));
            }
            return departments;
        }

        public async Task<MedicalClinicModel> GetAsync(int id)
        {
            var entity = await _service.ReadByIdAsync(id);
            return _mapper.Map<MedicalClinicEntity, MedicalClinicModel>(entity);
        }

        public async Task<bool> UpdateAsync(MedicalClinicModel model)
        {
            var entity = _mapper.Map<MedicalClinicModel, MedicalClinicEntity>(model);
            return await _service.UpdateAsync(entity);
        }
    }
}
