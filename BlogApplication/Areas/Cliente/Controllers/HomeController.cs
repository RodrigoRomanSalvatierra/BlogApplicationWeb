using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogApplication.Models;
using BlogApplication.AccesoDatos.Data.Repository;
using BlogApplication.Modelos.ViewModels;
using BlogApplication.Modelos;

namespace BlogApplication.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        // variable de tipo IContenedor general
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            // instanciamos el ViewModel
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(),
                ListaArticulos = _contenedorTrabajo.Articulo.GetAll()
            };
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            // buscamos el objeto articulo con Id = x en la Bd y lo retornamos
            var articuloFromDb = _contenedorTrabajo.Articulo.GetFirstOrDefault(articulo => articulo.Id == id);
            return View(articuloFromDb);
        }
    }
}
