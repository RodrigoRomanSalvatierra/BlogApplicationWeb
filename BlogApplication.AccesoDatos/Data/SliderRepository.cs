using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApplication.AccesoDatos.Data
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        // instancia del DbContext
        private readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Slider slider)
        {
            // primero obtenemos los valores del registro por el id que tenia en la BD, y lo instanciamos en objFromDb
            var objFromDb = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            // actualizamos los campos que recupero del objeto con los nuevos valores que llegan por paramentro
            objFromDb.Nombre = slider.Nombre;
            objFromDb.Estado = slider.Estado;
            objFromDb.UrlImagen = slider.UrlImagen;
        }
    }
}
