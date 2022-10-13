using Microsoft.AspNetCore.Authorization;

namespace pruebaED01.CustomSecurity
{
    public class AuthorizeByRoleAttribute : AuthorizeAttribute
    {
        public class RolesAuthorizeAttribute : AuthorizeAttribute
        {
            public RolesAuthorizeAttribute(params string[] roles)
            {
                Roles = String.Join(",", roles);
            }
        }
        public const string administrador= "Administrador";
        public const string recursos_humanos = "RecursosHumanos";
        public const string contabilidad = "Contabilidad";
    }

    

}
