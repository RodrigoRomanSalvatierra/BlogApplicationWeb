using BlogApplication.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        // metodos unicos por cada entidad
        IEnumerable<SelectListItem> GetListaCategorias();

        void Update(Categoria categoria);
    }
}
