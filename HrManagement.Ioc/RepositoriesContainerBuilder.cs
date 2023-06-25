using Autofac;
using HrManagement.Data.Repositories.CompanyRepositories;
using HrManagement.Data.Repositories.GenericsRepositories;
using HrManagement.Data.Repositories.ThirdPartyServicesRepository.Medical;
using HrManagement.Domain.Repositories.Company;
using HrManagement.Domain.Repositories.Generics;
using HrManagement.Domain.Repositories.ThirdPartyServices.Medical;

namespace HrManagement.Ioc
{
    public class RepositoriesContainerBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
           
            builder.RegisterType<MedicalClinicRepository>().As<IMedicalClinicRepository>().InstancePerLifetimeScope();
           
            builder.RegisterType<MedicalExamRepository>().As<IMedicalExamRepository>().InstancePerLifetimeScope();
        }
    }
}
