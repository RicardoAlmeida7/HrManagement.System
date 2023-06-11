using HrManagement.Data.Context;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.ThirdPartyServicesRepository.Medical
{
    public class MedicalExamRepository : BaseRepository<MedicalExamEntity>, IMedicalExamRepository
    {
        public MedicalExamRepository(DbContextOptions<HrManagementContext> contextOptions) 
            : base(contextOptions)
        {
        }
    }
}
