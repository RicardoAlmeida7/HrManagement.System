using AutoMapper;
using HrManagement.AppService.ViewModels.Company;
using HrManagement.AppService.ViewModels.Generics;
using HrManagement.AppService.ViewModels.ThirdPartyServices.Medical;
using HrManagement.AppService.ViewModels.UsersViewModel;
using HrManagement.Domain.Entities;
using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using HrManagement.Security;

namespace HrManagement.AppService.AutoMapper
{
    public class MappingProfileEntityToView : Profile
    {
        public MappingProfileEntityToView()
        {
            CreateMap<ApplicationUser, UserPageModel>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<DepartmentEntity, DepartmentModel>();
            CreateMap<EmployeeEntity, EmployeeModel>();
            CreateMap<ContactEntity, ContactModel>();
            CreateMap<AddressEntity, AddressModel>();
            CreateMap<MedicalClinicEntity, MedicalClinicModel>();
            CreateMap<MedicalExamEntity, MedicaExamModel>();
        }
    }
}
