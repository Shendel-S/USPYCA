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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Formulario()
        {
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

    }
}