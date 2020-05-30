using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Areas.Admin.Controllers
{
    // para proteger nuestras rutas de acceso por url, sino esta logeado en el sistema
    [Authorize]
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        // instancia acceder a la unidad de trabajo en donde se tiene el Repositorio
        private readonly IContenedorTrabajo _contenedorTrabajo;
        // instancia para trabajar con subida de archivos
        // IWebHostEnvironment = Obtiene o establece un IFileProvider que apunta a WebRootPath .
        private readonly IWebHostEnvironment _hostingEnvironment;

        // crear constructor | ctor tab
        public ArticulosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // para poder mostrar el nombre de la categoria NO lo podremos hacer ya que ese campo NO se encuentra
            // en nuestro MODELO ARTICULO para ello se usan los ViewModel
            // ViewModel = se usa para representar algo en la vista que no esta ya contenido por un modelo existente

            // instanciamos el ViewModel
            ArticuloViewModel articuloViewModel = new ArticuloViewModel()
            {
                // accedemos al modelo de Articulo y a la lista de categorias
                Articulo = new Modelos.Articulo(),
                // accedemos al contenedor de trabajo para obtener la lista de categoria
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            return View(articuloViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloViewModel articuloViewModel)
        {
            if (ModelState.IsValid)
            {
                // para poder acceder a la ruta principal wwwroot del proyecto
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                // verificamos si es un articulo
                if (articuloViewModel.Articulo.Id == 0)
                {
                    // clase que nos permite crear una cadena de caracteres, esto con el fin de tener nombres de
                    // archivos unicos en la BD
                    // Representa un identificador único global (GUID).
                    string nombreArchivo = Guid.NewGuid().ToString();
                    // ruta en donde se subiran los archivos, raiz wwwroot
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    // obtener la extension del archivo
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    articuloViewModel.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                    // asignamos la fecha actual del servidor
                    articuloViewModel.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Add(articuloViewModel.Articulo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
            }
            // si sucedio algun error, volvemos al formuario
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloViewModel articuloViewModel = new ArticuloViewModel()
            {
                Articulo = new Modelos.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            if(id != null)
            {
                articuloViewModel.Articulo = _contenedorTrabajo.Articulo.Get(id.GetValueOrDefault());
            }
            return View(articuloViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloViewModel articuloViewModel)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                //Obtenemos el objeto de Articulo por el id
                var articulosFromDb = _contenedorTrabajo.Articulo.Get(articuloViewModel.Articulo.Id);

                // verificamos si la imagen existe y se ha cambiado
                if (archivos.Count > 0)
                {
                    // Editamos la imagen
                    string nombreArchivo = Guid.NewGuid().ToString();
                    // ruta en donde se subiran los archivos, raiz wwwroot
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    // obtener la extension del archivo
                    var extension = Path.GetExtension(archivos[0].FileName);

                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articulosFromDb.UrlImagen.TrimStart('\\'));

                    // validamos si la imagen que ingresa ya existe en la carpeta, entonces la borramos
                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }
                    // subir nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    articuloViewModel.Articulo.UrlImagen = @"\imagenes\articulos\" + nombreArchivo + nuevaExtension;
                    // asignamos la fecha actual del servidor
                    articuloViewModel.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Update(articuloViewModel.Articulo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Imagen ya existe pero NO se va ha reemplazar
                    // conservar la imagen que ya esta en la BD
                    articuloViewModel.Articulo.UrlImagen = articulosFromDb.UrlImagen;
                }

                _contenedorTrabajo.Articulo.Update(articuloViewModel.Articulo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // obtenemos el articulo segun su id
            var articuloFromDb = _contenedorTrabajo.Articulo.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            // cortamos los caracteres \
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, articuloFromDb.UrlImagen.TrimStart('\\'));

            // buscamos SI la imagen existe
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if(articuloFromDb == null)
            {
                return Json(new { success = false, message = "Error al Borrar articulo" });
            }

            _contenedorTrabajo.Articulo.Remove(articuloFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Articulo eliminado Exitosamente" });


        }

        #region Llamada a las API
        [HttpGet]
        public IActionResult GetAll()
        {
            // el metodo GetAll() lo traemos desde la interface del repositorio general (IRepository)
            // en el GetAll() tambien traemos los datos del modelo categoria, para ver a que categoria pertenece el articulo
            // podriamos incluir N cantidad de Modelos PERO siempre y cuando esten relacionados desde el MODELO
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria") });
        }
        #endregion
    }
}