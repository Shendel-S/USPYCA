using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
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

        public List<SelectListItem> Tramite()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Vacunación antirrábica felina y canina",
                    Value = "1"
                },

                new SelectListItem()
                {
                    Text = "Esterilización canina y felina",
                    Value = "2"
                },
                new SelectListItem ()
                {
                    Text = "Recepción de cadáveres de origen animal",
                    Value = "3"
                },
                new SelectListItem ()
                {                    
                    Text = "Curso dueño Responsable",
                    Value = "4"
                }
            };
        }

        public List<Requisito> ListadoRequisitos(int idTramite)
        {
            using (var db = new ApplicationDbContext())
            {
                var Requisitos = db.Requisitos.
                    Where(x => x.IdTramite == idTramite).
                    ToList();
                return Requisitos;
            }
        }

        //Listado de solicitudes entrante desde formulario

        public List<Solicitud> SolicitudesVacunacion(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Solis = db.Solicitudes.Where(x =>x.Revisado==false && x.Tramite_id==1).
                    ToList();
                return Solis;
            }
        }
        

        //// Detalles de registros (Gestión Servidor Publico)

        public Solicitud FormularioCompleto (int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Formulario = db.Solicitudes.Where(x => x.Id == id)
                    .Include(x => x.Animales)
                    .Include(x => x.Ciudadanos)
                    .Include(x => x.Ciudadanos.DireccionCiudadano).FirstOrDefault();
                return Formulario;
            }
        }

        internal void EditarSol(Solicitud model)
        {
            
            using (var db = new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Modified;
                //db.Entry(model.Animales).State = EntityState.Modified;
                //db.Entry(model.Ciudadanos).State = EntityState.Modified;
                //db.Entry(model.Ciudadanos.DireccionCiudadano).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

    }
}