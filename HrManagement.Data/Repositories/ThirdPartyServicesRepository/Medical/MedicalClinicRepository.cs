using HrManagement.Data.Context;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.ThirdPartyServicesRepository.Medical
{
    public class MedicalClinicRepository : BaseRepository<MedicalClinicEntity>, IMedicalClinicRepository
    {
        public MedicalClinicRepository(DbContextOptions<HrManagementContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
