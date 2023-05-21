namespace HrManagement.EmailService
{
    public interface IEmailService
    {
        void SendEmail(string recipeint, string subject, string body);
    }
}
