using BlogApplication.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApplication.AccesoDatos.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        //constructor
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            // anadir la entidad a la BD.
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            // buscar el registro de la entidad por el id
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // si se estan tratando de filtrar los datos
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // include Properties separadas por comas, por si necesitamos devolver otros parametros de otras tablas relacionadas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            // validamos si tenemos ordenamiento
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            // retornamos siempre
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // si se estan tratando de filtrar los datos
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // include Properties separadas por comas, por si necesitamos devolver otros parametros de otras tablas relacionadas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            // buscamos la entidad que queremos eliminar
            T entityRemove = dbSet.Find(id);
            // eliminamos la entidad encontrada
            Remove(entityRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
