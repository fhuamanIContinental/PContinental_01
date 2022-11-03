using AutoMapper;
using pruebaED01.Model;
using pruebaED01.Model.Common;

namespace pruebaED01.Mapper
{
    public class AutoMapperProfile: Profile
    {
        //MenuResponse
        //Menu

        public AutoMapperProfile()
        {
            
            //CreateMap<MenuResponse, Menu>();
            //CreateMap<Menu, MenuResponse>();
            CreateMap<MenuResponse, Menu>().ReverseMap();


            CreateMap<List<MenuResponse>, List<Menu>>().ReverseMap();
        }
    }
}