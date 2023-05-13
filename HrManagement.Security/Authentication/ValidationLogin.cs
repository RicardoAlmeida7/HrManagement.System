using Microsoft.AspNetCore.Identity;

namespace HrManagement.Security.Authentication
{
    public class ValidationLogin
    {
        public static string Validation(SignInResult signInResult, int attempt)
        {
            if (signInResult.IsLockedOut)
                return "Falha na autenticação. Usuário bloqueado temporariamente.";

            string message = "Falha na autenticação. Verifique o nome e senha.";
            if (attempt != 0)
            {
                message += $" Tentativa {attempt}/3.";
            }
            return message;
        }
    }
}
