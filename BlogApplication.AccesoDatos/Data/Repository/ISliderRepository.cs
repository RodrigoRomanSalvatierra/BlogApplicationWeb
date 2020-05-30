using BlogApplication.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    public interface ISliderRepository: IRepository<Slider>
    {
        // metodos unicos por cada entidad
        // instancio el Modelo en la variable slider
        void Update(Slider slider);
    }
}
