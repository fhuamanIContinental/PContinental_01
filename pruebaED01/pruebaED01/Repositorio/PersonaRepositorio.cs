using Microsoft.EntityFrameworkCore;
using pruebaED01.Model;
using pruebaED01.Model.RequestResponse;

namespace pruebaED01.Repositorio
{
    public class PersonaRepositorio
    {
        _dbContext db = new _dbContext();
        public List<Persona> getAll()
        {
            List<Persona> lst = db.Personas.ToList();
            return lst;
        }

        public List<Persona> getAllComplete()
        {
            List<Persona> lst = 
                db.Personas
                .Include(x => x.PersonaDireccions)
                .ToList();
            return lst;
        }


        public Persona getById(int id)
        {
            Persona registro = db.Personas.Find(id);
            return registro;
        }

        public Persona create(Persona request)
        {
            //INSERT INTO 
            db.Personas.Add(request);
            db.SaveChanges();
            return request;
        }

        public Persona update(Persona request)
        {
            //UPDATE TABLE SET COLUMN 1 = AAS
            db.Personas.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Persona registro = db.Personas.Find(id);
            db.Personas.Remove(registro);
            return db.SaveChanges();
        }


        public GenericFilterResponse<Persona> getPersonasPorFiltro(GenericFilterRequest filter)
        {

            GenericFilterResponse<Persona> res = new GenericFilterResponse<Persona>();

            List<Persona> lista = new List<Persona>();
            //
            var query = db.Personas.Where(x => x.Id == x.Id);
            filter.filters.ForEach(item => { 
            
                if(item.value != "")
                {
                    switch(item.name.ToLower())
                    {
                        case "id":
                            query = query.Where(x => x.Id == int.Parse(item.value));
                            break;
                        case "tipo_documento":
                            // .Contains ==> select * from persona where nombre like '%fran%'
                            query = query.Where(x => x.TipoDocumento.ToLower().Contains(item.value.ToLower()));
                            break;
                        case "numero_documento":
                            query = query.Where(x => x.NumeroDocumento.ToLower().Contains(item.value.ToLower()));
                            break;
                        case "tipo_persona":
                            query = query.Where(x => x.TipoPersona.ToLower().Contains(item.value.ToLower()));
                            break;
                        case "full_name":
                            query = query.Where(x => x.FullName.ToLower().Contains(item.value.ToLower()));
                            break;
                        case "genero": query = query.Where(x => x.Genero.ToLower().Contains(item.value.ToLower()));
                            break;
                    }

                }



            });

            //query.OrderBy(x => x.apellido_paterno).ThenBy(x => x.apellido_materno);
            //if (filter.orders.Count > 0)
            //{
            //    filter.orders.ForEach(item => {
            //        query = query.OrderBy(x => x.nombre);
            //    });
            //}

            // select * from persona where ........ limit 4;
            res.registros_totales = query.Count();
            res.list = query
                .Skip((filter.page - 1) * filter.quantity).Take(filter.quantity).ToList();



            return res;
        }

    }
}
