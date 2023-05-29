using Autofac;
using HrManagement.AppService.AutoMapper.UserService;
using HrManagement.Security.Authentication;
using HrManagement.Security.ManagementRoles;
using HrManagement.Security.ManagementUsers;

namespace HrManagement.Ioc
{
    public class SecurityContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerRequest();
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerLifetimeScope();

            builder.RegisterType<ManagementRoles>().As<IManagementRoles>().InstancePerRequest();
            builder.RegisterType<ManagementRoles>().As<IManagementRoles>().InstancePerLifetimeScope();

            builder.RegisterType<ManagementUsers>().As<IManagementUsers>().InstancePerRequest();
            builder.RegisterType<ManagementUsers>().As<IManagementUsers>().InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
