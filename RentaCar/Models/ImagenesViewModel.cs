using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentaCar.Models
{
    public class ImagenesViewModel
    {
        public string IdImagen { get; set; }

        [Display(Name = "Titulo Imagen")]
        [Required(ErrorMessage = "Debe ingresar un Titulo Valido.")]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }
        public string Ruta { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}