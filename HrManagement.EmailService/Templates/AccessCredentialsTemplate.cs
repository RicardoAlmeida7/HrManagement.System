namespace HrManagement.EmailService.Templates
{
    public class AccessCredentialsTemplate
    {
        public static string Build(string userName, string tempPassword)
        {
            return $"<h1>Credenciais de acesso temporário</h1><br/>" +
                                            $"<h3>Ao realizar o primeiro acesso você será redirecionado(a)" +
                                            $" para uma tela de redefinição de senha.</h3><br/>" +
                                            $"<a>Usuário: </a> " +
                                            $"<a><strong>{userName}</strong></a><br/>" +
                                            $"<a>Senha: </a> " +
                                            $"<a><strong>{tempPassword}</strong></a><br/>";
        }
    }
}
