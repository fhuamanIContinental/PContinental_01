using pruebaED01.Model.RequestResponse;

namespace pruebaED01.Negocio
{
    public class AuthNegocio
    {


        public bool login(LoginRequest request)
        {

            // buscar al usuario por username
            // encriptar / desencriptar el password (base de datos / request)
            // comparar los datos
            if (request.UserName == "admin" && request.Password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
