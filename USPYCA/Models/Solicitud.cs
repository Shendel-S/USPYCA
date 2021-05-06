using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USPYCA.Models
{
    public class Solicitud
    {

        public Solicitud() { }

        public int Id { get; set; }

        public int Folio { get; set; }
                
        public DateTime Fecha { get; set; }

        public bool Revisado { get; set; }

        public string Comentarios { get; set; }
                   
        public Ciudadano Ciudadanos { get; set; }     
        
        public Animal Animales { get; set; }

        public int Tramite_id { get; set; }

    }
}