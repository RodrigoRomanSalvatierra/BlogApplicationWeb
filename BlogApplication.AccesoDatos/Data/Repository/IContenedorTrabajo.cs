using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo: IDisposable
    {
        // en esta unidad de trabajo vamos a contener a todos nuestros Repositorios, para poder acceder a cada uno de ellos
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }


        void Save();
    }
}
