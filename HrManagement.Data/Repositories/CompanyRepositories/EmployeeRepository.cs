using HrManagement.Data.Context;
using HrManagement.Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.CompanyRepositories
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DbContextOptions<HrManagementContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
