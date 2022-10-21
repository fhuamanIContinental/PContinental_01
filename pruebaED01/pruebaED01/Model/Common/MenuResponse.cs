namespace pruebaED01.Model.Common
{
    public class MenuResponse: Menu
    {

        public virtual List<MenuResponse> SubMenu { get; set; }
    }
}
