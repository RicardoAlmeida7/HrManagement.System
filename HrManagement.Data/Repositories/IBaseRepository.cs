namespace HrManagement.Data.Repositories
{
    public interface IBaseRepository<BaseEntity>
    {
        Task<bool> CreateAsync(BaseEntity entity);

        Task<BaseEntity> ReadByIdAsync(int id);

        Task<BaseEntity> ReadByIdAsync(Guid id);

        IEnumerable<BaseEntity> ReadAll();

        Task<bool> UpdateAsync(BaseEntity entity);

        Task<bool> DeleteAsync(BaseEntity entity);

        void Dispose();
    }
}
