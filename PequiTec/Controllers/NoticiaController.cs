using PequiTec._Repositorio;
using PequiTec.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PequiTec.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NoticiaController : Controller
    {
        NoticiaRepositorio _NREP = new NoticiaRepositorio();
        // GET: Noticia
        public ActionResult Index()
        {
            return View(_NREP.Listar());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase arquivo, Noticia Item)
        {
            Item.Data_Noticia = DateTime.Now;

            string caminho = Path.GetFileName(arquivo.FileName.Split('.')[0] + DateTime.Now.ToBinary() + "." + arquivo.FileName.Split('.')[1]);
            Item.Anexo = "../../../Content/img/imgNoticia/" + caminho;
            var path = Path.Combine(Server.MapPath("~/Content/img/imgNoticia"), caminho);
            arquivo.SaveAs(path);

            _NREP.Adicionar(Item);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int ID)
        {
            return View(_NREP.GetById(ID));
        }
        public PartialViewResult DeletarNoticia(int ID)
        {
            return PartialView(_NREP.GetById(ID));
        }
        [HttpPost]
        public ActionResult DeletarNoticia(Noticia a)
        {
            _NREP.Deletar(a);
            return RedirectToAction("Index");
        }
        public ActionResult EditarNoticia(int ID)
        {
            return View(_NREP.GetById(ID));
        }
        [HttpPost]
        public ActionResult EditarNoticia(HttpPostedFileBase arquivo, Noticia Item, string anexoAtual)
        {
            if (ModelState.IsValid)
            {
                Item.Data_Noticia = DateTime.Now;
                if (arquivo != null)
                {
                    string caminho = Path.GetFileName(arquivo.FileName.Split('.')[0] + DateTime.Now.ToBinary() + "." + arquivo.FileName.Split('.')[1]);
                    Item.Anexo = "../../../Content/img/imgNoticia/" + caminho;
                    var path = Path.Combine(Server.MapPath("~/Content/img/imgNoticia"), caminho);
                    arquivo.SaveAs(path);

                    _NREP.Update(Item);
                    return RedirectToAction("Index");
                }
                Item.Anexo = anexoAtual;

                _NREP.Update(Item);
                return RedirectToAction("Index");
            }
            return View(Item);
        }

        //public PartialViewResult NoticiaHome()
        //{
        //    return PartialView();
        //}

        //public PartialViewResult TodasNoticias()
        //{
        //    List<Noticia> noticias;
        //    try
        //    {
        //        noticias = _NREP.listar();
        //    }
        //    catch (Exception)
        //    {
        //        noticias = new List<Noticia>();
        //    }
        //    return PartialView(noticias);
        //}

        //public PartialViewResult NoticiasEmAlta()
        //{
        //    List<Noticia> noticias;
        //    try
        //    {
        //        noticias = _NREP.listarNoticiasEmAlta();
        //    }
        //    catch (Exception)
        //    {
        //        noticias = new List<Noticia>();
        //    }
        //    return PartialView(noticias);
        //}

        //public PartialViewResult NoticiaEspecifica(int ID_Noticia)
        //{
        //    return PartialView(_NREP.getById(ID_Noticia));
        //}
    }
}