namespace pruebaED01.Model.Common
{
    public class InfoRequest
    {
        public TokenClaims Claims { get; set; }
        public ApiRequestContext RequestHttp { get; set; }
    }

    public class TokenClaims
    {
        public int user_id { get; set; }
        public string nombre { get; set; }
        public string role { get; set; }
    }
    public class ApiRequestContext
    {
        public string ip { get; set; } // IP hizo la llamada (PERÚ) IP de la que comunica es de nuestro de Internet
        public string absoluteUri { get; set; } // www.linio.com
        public string absolutePath { get; set; } // www.sagafallabela.com
        public string host { get; set; } //
        public string method { get; set; } // GET POST PUT DELETE
        public string userAgent { get; set; } // cell, compu, chrome / firefox / postman / IE / edge
        public string controller { get; set; } //
        public string bodyRequest { get; set; } // que información envio en la petición
    }
}
