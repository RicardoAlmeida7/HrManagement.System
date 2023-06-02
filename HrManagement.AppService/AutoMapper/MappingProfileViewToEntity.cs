using AutoMapper;
using HrManagement.AppService.ViewModels.UsersViewModel;
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
        }
    }
}
