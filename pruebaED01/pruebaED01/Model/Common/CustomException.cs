namespace pruebaED01.Model.Common
{
    public class CustomException : Exception
    {
        public int httpCode = 0;
        public int errorCode = 500;// ConstansResponse.ERROR_NO_CONTROLADO_CODIGO;
        public string tipoError = "";
        public string mensaje = "";

        public CustomException() : base()
        {

        }

        public CustomException(string message, int httpCode)
        {
            this.httpCode = httpCode;
            this.mensaje = message;
        }

        public CustomException(string message, int httpCode, int erroCode, string tipoError) : base(message)
        {
            this.httpCode = httpCode;
            this.errorCode = erroCode;
            this.mensaje = message;
            this.tipoError = tipoError;
        }
        public CustomException(string message, int httpCode, int erroCode, string tipoError, Exception inner) : base(message, inner)
        {
            this.httpCode = httpCode;
            this.errorCode = erroCode;
            this.mensaje = message;
            this.tipoError = tipoError;
        }
    }
}