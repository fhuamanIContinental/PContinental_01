using pruebaED01.Model;

namespace pruebaED01.Repositorio
{
    public class PersonaTipoDireccionRepositorio
    {

        _dbContext db = new _dbContext();
        public List<PersonaTipoDireccion> getAll()
        {
            List<PersonaTipoDireccion> lst = db.PersonaTipoDireccion.ToList();
            return lst;
        }

        public PersonaTipoDireccion getById(int id)
        {
            PersonaTipoDireccion registro = db.PersonaTipoDireccion.Find(id);
            return registro;
        }

        public PersonaTipoDireccion create(PersonaTipoDireccion request)
        {
            //INSERT INTO 
            db.PersonaTipoDireccion.Add(request);
            db.SaveChanges();
            return request;
        }

        public PersonaTipoDireccion update(PersonaTipoDireccion request)
        {
            //UPDATE TABLE SET COLUMN 1 = AAS
            db.PersonaTipoDireccion.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            PersonaTipoDireccion registro = db.PersonaTipoDireccion.Find(id);
            db.PersonaTipoDireccion.Remove(registro);
            return db.SaveChanges();
        }

    }
}
