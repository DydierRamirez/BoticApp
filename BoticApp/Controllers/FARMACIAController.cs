using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoticApp.Models;

namespace BoticApp.Controllers
{
    public class FARMACIAController : Controller
    {
        private boticaapEntities1 db = new boticaapEntities1();

        // GET: FARMACIA
        public ActionResult Index()
        {
            return View(db.FARMACIA.ToList());
        }

        // GET: FARMACIA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FARMACIA fARMACIA = db.FARMACIA.Find(id);
            if (fARMACIA == null)
            {
                return HttpNotFound();
            }
            return View(fARMACIA);
        }

        // GET: FARMACIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FARMACIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FARMACIA,RAZON_SOCIAL,NIT,DIRECCION,TELEFONO,USUARIO,CLAVE,FECHA_CREACION,FECHA_MODIFICACION")] FARMACIA fARMACIA, string Clave2)
        {
            
                var max = db.FARMACIA.OrderByDescending(x => x.ID_FARMACIA).FirstOrDefault();
                if (max != null)
                    fARMACIA.ID_FARMACIA = max.ID_FARMACIA + 1;
                else
                    fARMACIA.ID_FARMACIA = 1;

                fARMACIA.FECHA_CREACION = DateTime.Now;
            //validar contraseñas
            if (!fARMACIA.CLAVE.Equals(Clave2))
                throw new ApplicationException("Clave no coincide");
            else
            {
                fARMACIA.CLAVE = Util.Util.Encriptar(fARMACIA.CLAVE);
                db.FARMACIA.Add(fARMACIA);
                db.SaveChanges();
            }

            
            return Redirect("~/default.aspx");
        }

        // GET: FARMACIA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FARMACIA fARMACIA = db.FARMACIA.Find(id);
            if (fARMACIA == null)
            {
                return HttpNotFound();
            }
            return View(fARMACIA);
        }

        // POST: FARMACIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FARMACIA,RAZON_SOCIAL,NIT,DIRECCION,TELEFONO,USUARIO,CLAVE,FECHA_CREACION,FECHA_MODIFICACION")] FARMACIA fARMACIA, string Clave)
        {
            
            db.Entry(fARMACIA).State = EntityState.Modified;
            fARMACIA.CLAVE = Clave;
            fARMACIA.FECHA_MODIFICACION = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
            
        }

        // GET: FARMACIA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FARMACIA fARMACIA = db.FARMACIA.Find(id);
            if (fARMACIA == null)
            {
                return HttpNotFound();
            }
            return View(fARMACIA);
        }

        // POST: FARMACIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FARMACIA fARMACIA = db.FARMACIA.Find(id);
            db.FARMACIA.Remove(fARMACIA);
            db.SaveChanges();
            return RedirectToAction("Index");
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
