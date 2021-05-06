using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USPYCA.Models
{
    public class Animal

    {
        public Animal()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Especie")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Raza")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Edad")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
        [Display(Name = "Causa de Muerte")]
        public string CausadeMuerte { get; set; }

        

    }
}
