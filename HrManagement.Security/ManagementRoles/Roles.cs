namespace HrManagement.Security.ManagementRoles
{
    public class Roles
    {
        public const string ACTIVE = "Ativo";
        public const string ADMINISTRATOR = "Administrador";
        public const string SYSTEM_USER = "Usuário padrão";

        public static IList<String> GetAll()
        {
            return new List<string>()
            {
                ACTIVE, ADMINISTRATOR, SYSTEM_USER
            };
        }
    }
}
