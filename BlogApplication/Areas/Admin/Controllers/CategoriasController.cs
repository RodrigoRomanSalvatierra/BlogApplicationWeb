using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Areas.Admin.Controllers
{
    // para proteger nuestras rutas de acceso por url, sino esta logeado en el sistema
    [Authorize]
    // mapear el controlador al area correspondiente del Administrador
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        // instanciamos la unidad de trabajo el cual contiene todos los repositorios
        // _contenedorTrabajo = variable
        // contenedorTrabajo = parametro
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // contructor
        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            // con esta lo que realizamos es poder acceder a todas las entidades de la Unit of Work
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // metodo de tipo GET nos permitira mostrar el formulario de registro de Categoria
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Metodo de tipo POST para la creacion de una nueva categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            // validar si el modelo es valido
            if (ModelState.IsValid)
            {
                // instanciamos el contenedor de trabajo y accedemos al repositorio de categoria
                // agregamos el modelo recibido
                _contenedorTrabajo.Categoria.Add(categoria);
                // guardamos 
                _contenedorTrabajo.Save();
                // redireccionamos al index
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // instanciamos la entidad Categoria
            Categoria categoria = new Categoria();
            // a dicha instancia le pasamos el objeto a buscar segun el id
            categoria = _contenedorTrabajo.Categoria.Get(id);
            // si la respuesta es nula, entonces retornamos un registro No Encontrado
            if(categoria == null)
            {
                return NotFound();
            }
            // si hay datos en categoria retornamos la vista y le enviamos los datos de la categoria
            return View(categoria);
        }

        // Metodo de tipo POST para EDITAR de una categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria) // pasamos la entidad instanciada en una variable | categoria
        {
            // validar si el modelo es valido
            if (ModelState.IsValid)
            {
                // instanciamos el contenedor de trabajo y accedemos al repositorio de categoria y al metodo
                // actualizamos el modelo recibido
                _contenedorTrabajo.Categoria.Update(categoria);
                // guardamos 
                _contenedorTrabajo.Save();
                // redireccionamos al index
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }


        #region Llamadas ala API tipo Ajax
        // creamos una peticion para poder utilizar los DataTable y nos muestre los registros AJAX
        [HttpGet]
        public IActionResult GetAll()
        {
            // el metodo GetAll() lo traemos desde la interface del repositorio general (IRepository)
            return Json(new { data= _contenedorTrabajo.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // buscamos en la BD, en la Entidad Categoria el objeto con Id igual al parametro que recibimos
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if(objFromDb == null)
            {
                // aqui interactuamos con la funcion Delete(url) de categoria.js 
                //pasamos un JSON con el valor del mensaje que va a mostrar el toastr
                return Json(new { success = false, message = "Error al eliminar categoria" });
            }
            // en caso se encuentre un objeto dentro de la entidad Categoria, le indicamos que va ha ser eliminado
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            // guardamos cambios
            _contenedorTrabajo.Save();
            // retornamos el JSON con el mensaje para que sea emitido por el toastr
            return Json(new { success = true, message = "Eliminado Correctamente..!" });
        }
        #endregion
    }
}