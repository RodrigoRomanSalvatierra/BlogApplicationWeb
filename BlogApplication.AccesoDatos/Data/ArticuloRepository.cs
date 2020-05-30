using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApplication.AccesoDatos.Data
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        // instancia del DbContext
        private readonly ApplicationDbContext _db;

        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Articulo articulo)
        {
            // primero obtenemos los valores del registro por el id que tenia en la BD, y lo instanciamos en objDesdeDb
            var objFromDb = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id);
            // actualizamos los campos que recupero del objeto con los nuevos valores que llegan por paramentro
            objFromDb.Nombre = articulo.Nombre;
            objFromDb.Descripcion = articulo.Descripcion;
            objFromDb.UrlImagen = articulo.UrlImagen;
            objFromDb.CategoriaId = articulo.CategoriaId;
        }
    }
}
