using Microsoft.EntityFrameworkCore;
using pruebaED01.Model;

namespace pruebaED01.Repositorio
{
    public class PersonaDireccionRepositorio
    {
        _dbContext db = new _dbContext();
        public List<PersonaDireccion> getAll()
        {
            List<PersonaDireccion> lst = db.PersonaDireccions.ToList();
            return lst;
        }

        public List<PersonaDireccion> getAllComplete()
        {
            List<PersonaDireccion> lst = 
                db.PersonaDireccions
                //.Include(x => x.PersonaTipoDireccion)
                .ToList();
            return lst;
        }


        public PersonaDireccion getById(int id)
        {
            PersonaDireccion registro = db.PersonaDireccions.Find(id);
            return registro;
        }

        public PersonaDireccion create(PersonaDireccion request)
        {
            //INSERT INTO 
            db.PersonaDireccions.Add(request);
            db.SaveChanges();
            return request;
        }

        public PersonaDireccion update(PersonaDireccion request)
        {
            //UPDATE TABLE SET COLUMN 1 = AAS
            db.PersonaDireccions.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            PersonaDireccion registro = db.PersonaDireccions.Find(id);
            db.PersonaDireccions.Remove(registro);
            return db.SaveChanges();
        }


    }
}
