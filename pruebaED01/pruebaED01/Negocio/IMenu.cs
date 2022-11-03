using pruebaED01.Model.Common;

namespace pruebaED01.Negocio
{
    public interface IMenuNegocio<T>
    {
        List<MenuResponse> getByRole(short idRole);
    }
}
