using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.Modelos.ViewModels
{
    public class ArticuloViewModel
    {
        public Articulo Articulo { get; set; }

        // obtener lista de las categorias
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
