using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USPYCA.Models
{
    public class Direccion
    {

        public Direccion () { }


        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Calle { get; set; }
                
        public int Num_int { get; set; }

        public int Num_ext {get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        public string Municipio { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
        public int CP { get; set; }


    }
}
