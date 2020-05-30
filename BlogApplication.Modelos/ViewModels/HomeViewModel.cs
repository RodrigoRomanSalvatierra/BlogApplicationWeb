using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.Modelos.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }
    }
}
