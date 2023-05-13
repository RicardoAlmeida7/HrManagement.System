namespace HrManagement.Security.ManagementUsers
{
    public interface IManagementUsers
    {
        IList<ApplicationUser> GetAll();

        Task UnblockUsersAsync(string userId);

        Task CreateAdminAsync(string adminName, string fullName, string email, string password);
    }
}
