using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USPYCA.Models;

namespace USPYCA.Repository
{
    public class USPYCARepository
    {
        public string CrearSolicitud(Solicitud model)
        {
            string mensaje = "";

            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Solicitudes.Add(model);
                    db.SaveChanges();
                    mensaje = "Solicitud guardada";
                }
                catch { mensaje = "Error al guardar"; }
                return mensaje;
            }
        }
    }
}

