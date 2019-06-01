using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoticApp.Logica;
using BoticApp.Models;

namespace BoticApp.Controllers
{
    public class MEDICAMENTOController : Controller
    {
        private boticaapEntities1 db = new boticaapEntities1();

        // GET: MEDICAMENTO
        public ActionResult Index()
        {
            var mEDICAMENTO = db.MEDICAMENTO.Include(m => m.MEDICAMENTO_TIPO);
            return View(mEDICAMENTO.ToList());
        }

        // GET: MEDICAMENTO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTO.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTO/Create
        public ActionResult Create()
        {
            ViewBag.ID_MEDICAMENTO_TIPO = new SelectList(db.MEDICAMENTO_TIPO, "ID_MEDICAMENTO_TIPO", "MEDICAMENTO_TIPO1");
            return View();
        }

        public ActionResult Find()
        {
            ViewBag.ID_MEDICAMENTO_TIPO = new SelectList(db.MEDICAMENTO_TIPO, "ID_MEDICAMENTO_TIPO", "MEDICAMENTO_TIPO1");
            return View();
        }

        // POST: MEDICAMENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MEDICAMENTO,ID_MEDICAMENTO_TIPO,CODIGO,MEDICAMENTO1,DESCRIPCION")] MEDICAMENTO mEDICAMENTO)
        {
            if (ModelState.IsValid)
            {
                var max = db.MEDICAMENTO.OrderByDescending(x => x.ID_MEDICAMENTO).FirstOrDefault();
                if (max != null)
                    mEDICAMENTO.ID_MEDICAMENTO = max.ID_MEDICAMENTO + 1;
                else
                    mEDICAMENTO.ID_MEDICAMENTO = 1;

                
                db.MEDICAMENTO.Add(mEDICAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ID_MEDICAMENTO_TIPO = new SelectList(db.MEDICAMENTO_TIPO, "ID_MEDICAMENTO_TIPO", "MEDICAMENTO_TIPO1", mEDICAMENTO.ID_MEDICAMENTO_TIPO);
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTO.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MEDICAMENTO_TIPO = new SelectList(db.MEDICAMENTO_TIPO, "ID_MEDICAMENTO_TIPO", "MEDICAMENTO_TIPO1", mEDICAMENTO.ID_MEDICAMENTO_TIPO);
            ViewBag.Farmacias = null;
            return View(mEDICAMENTO);
        }

        // POST: MEDICAMENTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MEDICAMENTO,ID_MEDICAMENTO_TIPO,CODIGO,MEDICAMENTO1,DESCRIPCION")] MEDICAMENTO mEDICAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEDICAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MEDICAMENTO_TIPO = new SelectList(db.MEDICAMENTO_TIPO, "ID_MEDICAMENTO_TIPO", "MEDICAMENTO_TIPO1", mEDICAMENTO.ID_MEDICAMENTO_TIPO);
            ViewBag.Farmacias = null;
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTO.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICAMENTO);
        }

        // POST: MEDICAMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTO.Find(id);
            db.MEDICAMENTO.Remove(mEDICAMENTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult Medicamentos(string medicamento)
        {
            using (Medicamento prcMedicamento = new Medicamento())
            {
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(prcMedicamento.ObtenerMedicamentos(medicamento)));
            }
        }
        public ActionResult Farmacias(string id)
        {
            var farmacias = (from u in db.FARMACIA select u);
            ViewBag.Farmacias = farmacias.ToList();
            return View("Find");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
