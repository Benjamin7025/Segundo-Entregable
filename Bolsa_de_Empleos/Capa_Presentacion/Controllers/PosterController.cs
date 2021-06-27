using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using Capa_Datos;
using System.Web.Security;

namespace Capa_Presentacion.Controllers
{
    public class PosterController : Controller
    {
        PosterNegocio negocio = new PosterNegocio();

        // GET: Poster
        public ActionResult Index()
        {            
            ViewBag.items = negocio.LLenarDropDownList();
            return View(negocio.MostrarPoster());
        }

        public ActionResult IndexCrud()
        {           
            ViewBag.items = negocio.LLenarDropDownList();
            return View(negocio.MostrarPosterCrud());
        }

        public ActionResult Pruebas()
        {
            ViewBag.items = negocio.LLenarDropDownList();
            return View(negocio.MostrarPoster());
        }
           
        public ActionResult Index2([Bind(Include = "id,CATEGORIA")] CATEGORIA CATEGORIA)
        {           
            Bolsa_de_EmpleadosEntities db = new Bolsa_de_EmpleadosEntities();

            var categoria =  db.CATEGORIAS.Where(x => x.id == CATEGORIA.id).ToList();

            var datos = new List<DATOS_VACANTE>();
            foreach (var item in categoria)
            {
                datos = db.DATOS_VACANTE.Where(x => x.Categoria == item.CATEGORIA1).ToList();
            }
           
            foreach (var item in categoria)
            {
                ViewBag.categoria = item.CATEGORIA1;
            }
           
            datos.Reverse();
            return View(datos);
        }

        // GET: Poster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (negocio.Detail(id) == null)
            {
                return HttpNotFound();
            }
            return View(negocio.Detail(id));
        }

        // GET: Poster/Create
        public ActionResult Create()
        {
            ViewBag.items = negocio.LLenarDropDownList();
            return View();
        }

        // POST: Poster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Compañia,Tipo,Posicion,Ubicacion,Categoria,Descripcion_Trabajo,Como_Aplicar,Email")] DATOS_VACANTE VACANTES)
        {
            if (ModelState.IsValid)
            {
                negocio.InsertarPoster(VACANTES);
                return RedirectToAction("IndexCrud");
            }

            return View(VACANTES);
        }

        // GET: Poster/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.items = negocio.LLenarDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (negocio.Edit(id) == null)
            {
                return HttpNotFound();
            }
            return View(negocio.Edit(id));
        }

        // POST: Poster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Compañia,Tipo,Posicion,Ubicacion,Categoria,Descripcion_Trabajo,Como_Aplicar,Email")] DATOS_VACANTE VACANTE )
        {
            if (ModelState.IsValid)
            {
                negocio.EditarPoster(VACANTE);
                return RedirectToAction("IndexCrud");
            }
            return View(VACANTE);
        }

        // GET: Poster/Delete/5
        public ActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (negocio.Delete(id) == null)
            {
                return HttpNotFound();
            }
            return View(negocio.Delete(id));
        }

        // POST: Poster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            negocio.EliminarPoster(id);
            return RedirectToAction("IndexCrud");
        }
    }
}
