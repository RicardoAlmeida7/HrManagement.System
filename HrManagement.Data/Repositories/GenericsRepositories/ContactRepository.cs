using HrManagement.Data.Context;
using HrManagement.Domain.Entities;
using HrManagement.Domain.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Repositories.GenericsRepositories
{
    public class ContactRepository : BaseRepository<ContactEntity>, IContactRepository
    {
        public ContactRepository(DbContextOptions<HrManagementContext> contextOptions) 
            : base(contextOptions)
        {
        }
    }
}
