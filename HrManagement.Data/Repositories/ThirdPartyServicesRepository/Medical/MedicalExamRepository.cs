using HrManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.ThirdPartyServicesRepository.Medical
{
    public class MedicalExamRepository : BaseRepository<MedicalExamRepository>, IMedicalClinicRepository
    {
        public MedicalExamRepository(DbContextOptions<HrManagementContext> contextOptions) 
            : base(contextOptions)
        {
        }
    }
}
