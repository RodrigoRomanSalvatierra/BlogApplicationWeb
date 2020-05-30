using BlogApplication.Modelos;
using BlogApplication.Utilitarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Inicializador
{
    public class InicializadorDb : IInicializadorDb
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorDb(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Inicializar()
        {
            try
            {
                // verificamos si hay migraciones pendientes
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    // ejecutar las migraciones pendientes
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            // validamos si existe un rol con el nombre Admin
            if(_db.Roles.Any(rol => rol.Name == Constantes.Admin))
            {
                return;
            }

            // en el caso de que no existan roles, creamos los roles
            _roleManager.CreateAsync(new IdentityRole(Constantes.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constantes.Usuario)).GetAwaiter().GetResult();

            // crear Usuario
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "rroman00101",
                Email = "rodrigo_00101@hotmail.com",
                EmailConfirmed = true,
                Nombre = "Rodrigo Roman"
            }, "P@ssword2020").GetAwaiter().GetResult();

            // obtener el usuario
            ApplicationUser usuario = _db.ApplicationUser
                .Where(usuario => usuario.Email == "rodrigo_00101@hotmail.com")
                .FirstOrDefault();
            // asignamos el rol que se ha creado anteriormente
            _userManager.AddToRoleAsync(usuario, Constantes.Admin).GetAwaiter().GetResult();


        }
    }
}
