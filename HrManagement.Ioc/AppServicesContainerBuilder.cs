using Autofac;
using HrManagement.AppService.Services.CompanyServices.Department;
using HrManagement.AppService.Services.CompanyServices.Employee;
using HrManagement.AppService.Services.ThirdPartyServices.MedicalClinic;

namespace HrManagement.Ioc
{
    public class AppServicesContainerBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<MedicalClinicService>().As<IMedicalClinicService>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
        }
    }
}
