using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApplication.Modelos
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [Display(Name ="Nombre del articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Descripcion { get; set; }

        [Display(Name ="Fecha de creacion")]
        public string FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        // Agregamos la relacion con Categoria
        [Required]
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
