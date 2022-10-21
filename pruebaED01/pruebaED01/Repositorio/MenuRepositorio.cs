using pruebaED01.Constantes;
using pruebaED01.Model;
using pruebaED01.Model.Common;
using pruebaED01.Repositorio.Util;
using System.Net;

namespace pruebaED01.Repositorio
{
    public class MenuRepositorio : GenericRepository<Menu>
    {

        //public List<Menu> getAllOutPadre()
        //{
        //    return db.Menus.Where(x => x.id_status != statusConstants.deleted && x.padre != 0).Include(x => x.Status).ToList();
        //}

        public List<Menu> getByRole(short idRole)
        {
            try
            {
                List<Menu> list = (from a in db.MenuRoles
                                        join b in db.Menus on a.IdMenu equals b.Id
                                        where
                                            a.IdRole == idRole
                                            && b.IdStatus == 1
                                            && a.IdStatus == 1
                                        select new Menu
                                        {
                                            Id = b.Id,
                                            Name = b.Name,
                                            Description = b.Description,
                                            Icon = b.Icon,
                                            Datatarget = b.Datatarget,
                                            Url = b.Url,
                                            Padre = b.Padre,
                                            IdStatus = b.IdStatus,
                                            
                                        })
                             .OrderBy(x => x.Name).ToList();
                return list;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al listar", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }

        }

        //public GenericFilterResponse<MenuModel> getByFilter(GenericFilterRequest filter)
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
