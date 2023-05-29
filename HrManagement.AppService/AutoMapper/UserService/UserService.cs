using AutoMapper;
using HrManagement.AppService.ViewModels.UsersViewModel;
using HrManagement.Security;

namespace HrManagement.AppService.AutoMapper.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserPageModel GetUserPageModelFromApplicationUser(ApplicationUser user, string[] roles = null)
        {
            var userPageModel = _mapper.Map<ApplicationUser, UserPageModel>(user);
            if (userPageModel != null && roles != null)
            {
                userPageModel.Access = roles;
            }
            return userPageModel;
        }
    }
}
