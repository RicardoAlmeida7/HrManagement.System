using AutoMapper;
using HrManagement.Domain.Entities;
using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using HrManagement.Domain.ViewModels.Company;
using HrManagement.Domain.ViewModels.Generics;
using HrManagement.Domain.ViewModels.ThirdPartyServices.Medical;
using HrManagement.Domain.ViewModels.UsersViewModel;
using HrManagement.Security;

namespace HrManagement.AppService.AutoMapper
{
    public class MappingProfileViewToEntity : Profile
    {
        public MappingProfileViewToEntity()
        {
            CreateMap<UserPageModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<DepartmentModel, DepartmentEntity>();
            CreateMap<EmployeeModel, EmployeeEntity>();
            CreateMap<ContactModel, ContactEntity>();
            CreateMap<AddressModel, AddressEntity>();
            CreateMap<MedicalClinicModel, MedicalClinicEntity>();
            CreateMap<MedicaExamModel, MedicalExamEntity>();
        }
    }
}
