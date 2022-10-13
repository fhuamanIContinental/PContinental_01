namespace pruebaED01.Model.RequestResponse
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Perfil { get; set; }
        public string RefreshToken { get; set; }
        
        // que tenga que devolver el objeto usuario
    }
}
