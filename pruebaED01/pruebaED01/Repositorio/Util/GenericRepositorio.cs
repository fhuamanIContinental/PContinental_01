using Microsoft.EntityFrameworkCore;
using pruebaED01.Constantes;
using pruebaED01.Model;
using pruebaED01.Model.Common;
using System.Net;

namespace pruebaED01.Repositorio.Util
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal _dbContext db = new _dbContext();
        internal DbSet<TEntity> dbSet;
        public GenericRepository()
        {
            try
            {
                this.dbSet = db.Set<TEntity>();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual List<TEntity> getAll()
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                return query.ToList();

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual TEntity getById(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al buscar el registro", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual TEntity create(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al registrar", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual TEntity update(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
                db.SaveChanges();
                return entity;

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al actualizar", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual int delete(object id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                dbSet.Remove(entityToDelete);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al eliminar", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }

        }

        public virtual int updateMultipleItems(List<TEntity> lista)
        {
            try
            {
                dbSet.UpdateRange(lista);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al actualizar multiple", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual int deleteMultipleItems(List<TEntity> lista)
        {
            try
            {
                dbSet.RemoveRange(lista);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }

        }
        public virtual List<TEntity> insertMultiple(List<TEntity> lista)
        {
            try
            {
                dbSet.AddRange(lista);
                db.SaveChanges();
                return lista;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }
        public virtual List<TEntity> updateMultiple(List<TEntity> lista)
        {
            try
            {
                dbSet.UpdateRange(lista);
                db.SaveChanges();
                return lista;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

    }
}
