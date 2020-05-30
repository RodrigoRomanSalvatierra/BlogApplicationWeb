using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogApplication.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Areas.Admin.Controllers
{
    // para proteger nuestras rutas de acceso por url, sino esta logeado en el sistema
    [Authorize]
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        public IActionResult Index()
        {
            // acceder al usuario Autenticado actual en el sistema (administrador)
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            // obtenemos el Identificador unico del usuario actual autenticado
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // retornamos la lista de usuarios para la tabla menos el usuario actual autenticado en el sistema
            return View(_contenedorTrabajo.Usuario.GetAll(user => user.Id != usuarioActual.Value));
        }

        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // llamamos al repositorio Usuario y al metodo Bloquear pasandole el id
            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Desbloquear(string id)
        {
            // validar que el id no sea nulo
            if (id == null)
            {
                return NotFound();
            }
            // llamamos al repositorio Usuario y al metodo Bloquear pasandole el id
            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}