using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApplication.Modelos
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [Display(Name ="Nombre Slider")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public bool Estado { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Imagen de Slider")]
        public string UrlImagen { get; set; }
    }
}
