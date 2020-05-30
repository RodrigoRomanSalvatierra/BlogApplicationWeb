using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogApplication.Areas.Admin.Controllers
{
    // para proteger nuestras rutas de acceso por url, sino esta logeado en el sistema
    [Authorize]
    [Area("Admin")]
    public class SliderController : Controller
    {
        // instancia acceder a la interfaz de la unidad de trabajo en donde se tiene el Repositorio
        private readonly IContenedorTrabajo _contenedorTrabajo;
        // instancia para trabajar con subida de archivos
        // IWebHostEnvironment = Obtiene o establece un IFileProvider que apunta a WebRootPath .
        private readonly IWebHostEnvironment _hostingEnvironment;

        // crear constructor | ctor tab
        public SliderController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                // para poder acceder a la ruta principal wwwroot del proyecto
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                // verificamos si es un articulo
                if (slider.Id == 0)
                {
                    // clase que nos permite crear una cadena de caracteres, esto con el fin de tener nombres de
                    // archivos unicos en la BD
                    // Representa un identificador único global (GUID).
                    string nombreArchivo = Guid.NewGuid().ToString();
                    // ruta en donde se subiran los archivos, raiz wwwroot
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    // obtener la extension del archivo
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;

                    _contenedorTrabajo.Slider.Add(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
            }
            // si sucedio algun error, volvemos al formuario
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // instanciamos la entidad Categoria
            Slider slider = new Slider();
            // a dicha instancia le pasamos el objeto a buscar segun el id
            slider = _contenedorTrabajo.Slider.Get(id);
            // si la respuesta es nula, entonces retornamos un registro No Encontrado
            if (slider == null)
            {
                return NotFound();
            }
            // si hay datos en categoria retornamos la vista y le enviamos los datos de la categoria
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                //Obtenemos el objeto de Slider por el id
                var sliderFromDb = _contenedorTrabajo.Slider.Get(slider.Id);

                // verificamos si la imagen existe y se ha cambiado
                if (archivos.Count > 0)
                {
                    // Editamos la imagen
                    string nombreArchivo = Guid.NewGuid().ToString();
                    // ruta en donde se subiran los archivos, raiz wwwroot
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    // obtener la extension del archivo
                    var extension = Path.GetExtension(archivos[0].FileName);

                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, sliderFromDb.UrlImagen.TrimStart('\\'));

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

                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + nuevaExtension;

                    _contenedorTrabajo.Slider.Update(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Imagen ya existe pero NO se va ha reemplazar
                    // conservar la imagen que ya esta en la BD
                    slider.UrlImagen = sliderFromDb.UrlImagen;
                }

                _contenedorTrabajo.Slider.Update(slider);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // obtenemos el slider segun su id
            var sliderFromDb = _contenedorTrabajo.Slider.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            // cortamos los caracteres \
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, sliderFromDb.UrlImagen.TrimStart('\\'));

            // buscamos SI la imagen existe
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (sliderFromDb == null)
            {
                return Json(new { success = false, message = "Error al Borrar articulo" });
            }

            _contenedorTrabajo.Slider.Remove(sliderFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Slider eliminado Exitosamente" });

        }


        #region Llamada a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            // el metodo GetAll() lo traemos desde la interface del repositorio general (IRepository)
            return Json(new { data = _contenedorTrabajo.Slider.GetAll() });
        }
        #endregion
    }
}