using AutoMapper;
using pruebaED01.Model;
using pruebaED01.Model.Common;
using pruebaED01.Repositorio;

namespace pruebaED01.Negocio
{
    public class MenuNegocio:IMenuNegocio<Menu>
    {
        MenuRepositorio _menuRepositorio = new MenuRepositorio();
        private readonly IMapper _mapper;
        public MenuNegocio(IMapper mapper)
        {
            _mapper = mapper;
        }



        public List<Menu> getAll()
        {
            List<Menu> list = new List<Menu>();
            List<Menu> padres = new List<Menu>();
            list = _menuRepositorio.getAll();
            //padres = list.Where(x => x.padre == 0).ToList();

            //padres.ForEach(x => {
            //    x.sub_menu = list.Where(y => y.padre == x.id).ToList();
            //});

            return list;
        }

        public Menu getById(object id)
        {
            return _menuRepositorio.getById(id);
        }

        public Menu create(Menu menu)
        {
            return _menuRepositorio.create(menu);
        }

        public Menu update(Menu menu)
        {
            return _menuRepositorio.update(menu);
        }

        public int delete(short id)
        {
            return _menuRepositorio.delete(id);
        }

        public List<Menu> cargaMasiva(List<Menu> lista)
        {
            throw new NotImplementedException();
        }

        public List<Menu> insertMultiple(List<Menu> lista)
        {
            return _menuRepositorio.insertMultiple(lista);
        }

        public List<Menu> updateMultiple(List<Menu> lista)
        {
            return _menuRepositorio.updateMultiple(lista);
        }

        public int delete(object id)
        {
            return _menuRepositorio.delete(id);
        }

        public List<MenuResponse> getByRole(short idRole)
        {
            // vienen desde base de datos
            List<Menu> list = new List<Menu>();
            List<Menu> listPadre = new List<Menu>();

            // personalizadas
            List<MenuResponse> listPadreResponse = new List<MenuResponse>();
            List<MenuResponse> listResponse = new List<MenuResponse>();

            //estamos obteniendo información de la base de datos
            list = _menuRepositorio.getByRole(idRole);
            listPadre = list.Where(x => x.Padre == 0).ToList();


            listPadreResponse = _mapper.Map<List<MenuResponse>>(listPadre);
            listResponse = _mapper.Map<List<MenuResponse>>(list);


            ////vamos a pasar el modelo de Menu a MenuResponse
            //listPadre.ForEach(x => {
            //    MenuResponse tmp = new MenuResponse();
            //    tmp.Id = x.Id;
            //    tmp.Name = x.Name;
            //    tmp.Description = x.Description;
            //    tmp.Icon = x.Icon;
            //    tmp.Datatarget = x.Datatarget;
            //    tmp.Url = x.Url;
            //    tmp.Padre = x.Padre;
            //    tmp.IdStatus = x.IdStatus;
            //    tmp.SubMenu = new List<MenuResponse>();
            //    listPadreResponse.Add(tmp);
            //});

            //list.ForEach(x => {
            //    MenuResponse tmp = new MenuResponse();
            //    tmp.Id = x.Id;
            //    tmp.Name = x.Name;
            //    tmp.Description = x.Description;
            //    tmp.Icon = x.Icon;
            //    tmp.Datatarget = x.Datatarget;
            //    tmp.Url = x.Url;
            //    tmp.Padre = x.Padre;
            //    tmp.IdStatus = x.IdStatus;
            //    tmp.SubMenu = new List<MenuResponse>();
            //    listResponse.Add(tmp);
            //});

            listPadreResponse.ForEach(x => {
                x.SubMenu = listResponse.Where(t => t.Padre == x.Id).ToList();
            });

            return listPadreResponse;
        }


    }
}
