using HrManagement.Data.Context;
using HrManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.GenericsRepositories
{
    public class AddressRepository : BaseRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(DbContextOptions<HrManagementContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
