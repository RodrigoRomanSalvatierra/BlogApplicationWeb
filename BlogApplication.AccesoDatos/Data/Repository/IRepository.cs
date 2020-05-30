using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    // esta sera una clase que puede ser de diferente inplementacion
    public interface IRepository<T> where T: class // T = Clase
    {
        // aqui adicionamos los metodos que seran comunes para todos los repositorios
        T Get(int id); //Buscar un registro de una entidad por el id

        // retornar todos los registros de una entidad o filtrados (categorias, articulos ,etc)
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
        );

        // retornar el primero que encuentre
        T GetFirstOrDefault(
             Expression<Func<T, bool>> filter = null,
              string includeProperties = null
         );

        // metodo para agregar la entidad ala Base de datos
        void Add(T entity); // recibe la clase (T)

        // metodo para eliminar una entidad por identificador unico
        void Remove(int id);

        // metodo para eliminar una entidad entera
        void Remove(T entity);
    }
}
