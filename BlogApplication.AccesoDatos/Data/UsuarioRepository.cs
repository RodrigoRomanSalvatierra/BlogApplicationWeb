using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApplication.AccesoDatos.Data
{
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
       
        public void BloquearUsuario(string idUsuario)
        {
            // obtenemos al usuario
            var usuarioFromDb = _db.ApplicationUser.FirstOrDefault(user => user.Id == idUsuario);
            // bloqueamos desde la fecha actual + 5 dias
            usuarioFromDb.LockoutEnd = DateTime.Now.AddDays(5);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string idUsuario)
        {
            // obtenemos al usuario
            var usuarioFromDb = _db.ApplicationUser.FirstOrDefault(user => user.Id == idUsuario);
            // desbloqueamos Ahora en la fecha actual
            usuarioFromDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
