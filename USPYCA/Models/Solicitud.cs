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
                
        public DateTime Fecha { get; set; }

        public bool Revision { get; set; }

        public string Comentarios { get; set; }

        public Tramite Tipotramite { get; set; }
        
        public Ciudadano Ciudadanos { get; set; }
                     
    }
}