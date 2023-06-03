using HrManagement.Data.Context;
using HrManagement.Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.CompanyRepositories
{
    public class DepartmentRepository : BaseRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(DbContextOptions<HrManagementContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
