using Microsoft.EntityFrameworkCore;
using pruebaED01.Model;

namespace pruebaED01.Repositorio
{
    public class PersonaDireccionRepositorio
    {
        _dbContext db = new _dbContext();
        public List<PersonaDireccion> getAll()
        {
            List<PersonaDireccion> lst = db.PersonaDireccion.ToList();
            return lst;
        }

        public List<PersonaDireccion> getAllComplete()
        {
            List<PersonaDireccion> lst = 
                db.PersonaDireccion
                .Include(x => x.PersonaTipoDireccion)
                .ToList();
            return lst;
        }


        public PersonaDireccion getById(int id)
        {
            PersonaDireccion registro = db.PersonaDireccion.Find(id);
            return registro;
        }

        public PersonaDireccion create(PersonaDireccion request)
        {
            //INSERT INTO 
            db.PersonaDireccion.Add(request);
            db.SaveChanges();
            return request;
        }

        public PersonaDireccion update(PersonaDireccion request)
        {
            //UPDATE TABLE SET COLUMN 1 = AAS
            db.PersonaDireccion.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            PersonaDireccion registro = db.PersonaDireccion.Find(id);
            db.PersonaDireccion.Remove(registro);
            return db.SaveChanges();
        }


    }
}
