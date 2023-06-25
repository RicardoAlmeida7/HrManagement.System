namespace HrManagement.Domain.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(string recipeint, string subject, string body);
    }
}
