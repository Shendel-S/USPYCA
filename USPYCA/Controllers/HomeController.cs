using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult FormatoRecepcionCoA()
        {
            return View();
        }
        public ActionResult RespEsteril()
        {
            return View(); 
        }
        public ActionResult ListadoVacunacion()
        {
            int id=1;
            var lista = _repo.SolicitudesVacunacion(id);
            return View(lista);
        }
       
        public ActionResult DetallesVac (int id)
        {
            var InspectorCompleto = _repo.FormularioCompleto(id);
            ViewBag.WebId = id;
            return View(InspectorCompleto);
        }
    }
}
