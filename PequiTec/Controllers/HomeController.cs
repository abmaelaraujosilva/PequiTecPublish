using PequiTec._Repositorio;
using PequiTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PequiTec.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        NoticiaRepositorio _NREP = new NoticiaRepositorio();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult carosel()
        {
            return PartialView();
        }
        public ActionResult sobre()
        {
            return PartialView();
        }
        public ActionResult objetivo()
        {
            return PartialView();
        }
        public ActionResult projetos()
        {
            return PartialView();
        }
        public ActionResult historia()
        {
            return PartialView();
        }
        public ActionResult organograma()
        {
            return PartialView();
        }
        public ActionResult logos()
        {
            return PartialView();
        }
        public ActionResult comoIngressar()
        {
            return PartialView();
        }
        public ActionResult servicos()
        {
            return PartialView();
        }
        public ActionResult contatos()
        {
            return PartialView();
        }
        public ActionResult noticias()
        {
            List<Noticia> noticias;
            try
            {
                noticias = _NREP.Listar().ToList();
            }
            catch (Exception)
            {
                noticias = new List<Noticia>();
            }
            return PartialView(noticias);
        }

        public PartialViewResult DetalhesNoticia(int ID)
        {
            return PartialView(_NREP.GetById(ID));
        }
    }
}
