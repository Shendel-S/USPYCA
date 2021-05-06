using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USPYCA.Models
{
    public class Ubicacion
    {
        public Ubicacion() { }

        public int Id { get; set; }

        public int Latitud { get; set; }

        public int Longitud { get; set; }

        public string Direccion { get; set; }
        

    }
}