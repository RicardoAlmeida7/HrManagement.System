using AutoMapper;
using HrManagement.Domain.ViewModels.UsersViewModel;
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

        public ApplicationUser GetByUserPageModel(UserPageModel user)
        {
            return _mapper.Map<UserPageModel, ApplicationUser>(user);
        }
    }
}
