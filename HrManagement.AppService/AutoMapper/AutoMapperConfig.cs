using AutoMapper;

namespace HrManagement.AppService.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfileViewToEntity());
                x.AddProfile(new MappingProfileEntityToView());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
