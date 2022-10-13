using Microsoft.EntityFrameworkCore;
using pruebaED01.Model;

namespace pruebaED01.Repositorio
{
    public class PersonaRepositorio
    {
        _dbContext db = new _dbContext();
        public List<Persona> getAll()
        {
            List<Persona> lst = db.Persona.ToList();
            return lst;
        }

        public List<Persona> getAllComplete()
        {
            List<Persona> lst = 
                db.Persona
                .Include(x => x.direcciones)
                .ToList();
            return lst;
        }


        public Persona getById(int id)
        {
            Persona registro = db.Persona.Find(id);
            return registro;
        }

        public Persona create(Persona request)
        {
            //INSERT INTO 
            db.Persona.Add(request);
            db.SaveChanges();
            return request;
        }

        public Persona update(Persona request)
        {
            //UPDATE TABLE SET COLUMN 1 = AAS
            db.Persona.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Persona registro = db.Persona.Find(id);
            db.Persona.Remove(registro);
            return db.SaveChanges();
        }


    }
}
