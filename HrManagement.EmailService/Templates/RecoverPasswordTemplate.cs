namespace HrManagement.EmailService.Templates
{
    public class RecoverPasswordTemplate
    {
        public static string Build(string url)
        {
            return $"<h1>Recuperação de senha</h1><br/>" +
                                            $"<a href=\"{url}\" style=\"display:inline-block; " +
                                            $"background-color:#007bff;color:#fff; " +
                                            $"padding:10px 20px; " +
                                            $"text-decoration:none;\">" +
                                            $"Clique aqui para redefinir sua senha</a>";
        }
    }
}
