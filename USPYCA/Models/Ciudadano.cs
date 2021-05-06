using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USPYCA.Models
{
    public class Ciudadano

    {
        public Ciudadano () { 
         }

       public int Id  { get; set; }
     
       [Required (ErrorMessage = "Este campo es obligatorio")] 
       [RegularExpression ("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")] 
       [Display (Name = "Nombre")]
       public string Nombre { get; set; }

       [Required(ErrorMessage = "Este campo es obligatorio")]
       [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
       [Display(Name = "Apellido Paterno")]
       public string Apellido_Paterno { get; set; }

       [Required(ErrorMessage = "Este campo es obligatorio")]
       [RegularExpression("^[a-zA-ZÑñÁ-ÿ Ññ]*$", ErrorMessage = "*Solo se permiten letras.")]
       [Display(Name = "Apellido Materno")]
       public string Apellido_Materno { get;  set; }
              
       
       public  Direccion DireccionCiudadano { get; set; }

       [Required(ErrorMessage = "Este campo es obligatorio")]
       [Display(Name = "Correo Electrónico")]
       [EmailAddress(ErrorMessage = "Correo Electrónico Invalido")]
       public string CorreoElectronico { get; set; }

       [Required(ErrorMessage = "Este campo es obligatorio")]
       [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]  
       [Display (Name = "Número Telefónico")]
       public int Telefono { get; set; }

             
        
    }
}
