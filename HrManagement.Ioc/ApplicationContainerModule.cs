using Autofac;
using HrManagement.AppService.AutoMapper;

namespace HrManagement.Ioc
{
    public class ApplicationContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
