namespace pruebaED01.Model.RequestResponse
{
    //la "T" es un comodín persona / empleado / cliente
    public class GenericFilterResponse<T>
    {
        public int registros_totales { get; set; }
        public int nro_paginas { get; set; }
        public List<T> list { get; set; }
    }
}
