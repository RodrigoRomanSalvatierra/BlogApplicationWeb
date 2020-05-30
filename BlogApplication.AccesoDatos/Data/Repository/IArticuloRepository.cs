using BlogApplication.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    public interface IArticuloRepository: IRepository<Articulo>
    {
        // metodos unicos por cada entidad
        // instancio el Modelo en la variable articulo
        void Update(Articulo articulo);
    }
}
