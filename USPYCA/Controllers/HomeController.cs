using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using USPYCA.Models;
using USPYCA.Repository;

namespace USPYCA.Controllers
{
    public class HomeController : Controller
    {
        private USPYCARepository _repo;
        public HomeController()
        {
            _repo = new USPYCARepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Formulario()
        {
            ViewBag.tramiteItems = _repo.Tramite();
            return View();
        }
        [HttpPost]
        public ActionResult Formulario(Solicitud model)
        {
            model.Fecha = DateTime.Now;
            ViewBag.Mensaje = _repo.CrearSolicitud(model);
            return View("Confirmacion");
        }
        public ActionResult Confirmacion()
        {
            return View();
        }
        public ActionResult EligeTramite()
        {
            ViewBag.tramiteItems = _repo.Tramite();
            return View();
        }

        [HttpPost]
        public ActionResult EligeTramite(int TramiteElegido)
        {
            switch (TramiteElegido)
            {
                case 1:
                    return RedirectToAction("VacAntirrabicaFyC");
                case 2:
                    return RedirectToAction("RespEsteril");
                case 3:
                    return RedirectToAction("FormatoRecepcionCoA");
                case 4:
                    return RedirectToAction("CursoDueñoResponsable");

                default:
                    string Mess = "No seleccionó ningún trámite, por favor intente nuevamente";
                    return RedirectToAction("Aviso", "Home", new { Mess });
            }
        }
        public ActionResult Aviso(string Mess)
        {
            ViewBag.Mess = Mess;
            return View();
        }
        [HttpPost]
        public ActionResult ObtenerRequisitos(int idTramite)
        {
            try
            {
                var requisitos = _repo.ListadoRequisitos(idTramite);
                return View(requisitos);
            }
            catch (Exception e)
            {
                return Json(new { Error = true, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        private ActionResult View(Func<int, ActionResult> obtenerRequisitos)
        {
            throw new NotImplementedException();
        }
        public ActionResult CursoDueñoResponsable()
        {
            return View();
        }

        public ActionResult VacAntirrabicaFyC()
        {

            return View();
        }
        [HttpPost]        
        public ActionResult VacAntirrabicaFyC(Solicitud model)
        {
            model.Fecha = DateTime.Now;
            ViewBag.Mensaje = _repo.CrearSolicitud(model);
            return View("Confirmacion");
        }
       
        public ActionResult ListadoVacunacion()
        {
            int id=1;
            var lista = _repo.SolicitudesVacunacion(id);
            return View(lista);
        }
       
        public ActionResult DetallesVac (int id)
        {
            var DetallesSoli = _repo.FormularioCompleto(id);
            ViewBag.WebId = id;
            return View(DetallesSoli);
        }

        public ActionResult Revision(int id)
        {
            //var DetallesSoli = _repo.InfoFormCiuAni(id);
            ViewBag.WebId = id;
            return View();
        }

            [HttpPost]
        public ActionResult Revision (string body,  string Comen, string id)
        {
            int soliId = Int32.Parse(id);
            var Soli = _repo.FormularioCompleto(soliId);

            Soli.Revisado = true;
            Soli.Comentarios = Comen;
            //Guarda la revision
            _repo.EditarSol(Soli);

            //Se manda correo al ciudadano con la revison del sP
            //Se crea objeto de mailmessa
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(Soli.Ciudadanos.CorreoElectronico));
            email.From = new MailAddress("noreply@cizcalli.gob.mx");
            email.Subject = "USPYCA ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " )";
            string plantilla;
            using (StreamReader reader01 = new StreamReader(Server.MapPath(@"~/Content/aceptada.html")))
            {
                plantilla = reader01.ReadToEnd();
            }
            plantilla = plantilla.Replace("[Variable]", body + Comen);
            plantilla = plantilla.Replace("[Folio]", ""+Soli.Folio);
            email.Body = plantilla;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.cizcalli.gob.mx"; //'"mail.cizcalli.gob.mx"
            smtp.Port = 587; //'587
            smtp.Credentials = new System.Net.NetworkCredential("noreply@cizcalli.gob.mx", "N.Reply.2019");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(email);
                email.Dispose();
                ViewBag.Mensaje = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error enviando correo electrónico: " + ex.Message;
            }
            return View("Confirmacion");
        }
    }
}

