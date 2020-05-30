using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApplication.Modelos
{
    public class ApplicationUser: IdentityUser // heredamos de Identity para agregar estos campos a tabla AsNetUsers
    {
        [Required(ErrorMessage ="Campo requerido")]
        public string Nombre { get; set; }

        [MaxLength(150)]
        public string Direccion { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public string Pais { get; set; }
    }
}
