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
    public class USUARIOController : Controller
    {
        private boticaapEntities1 db = new boticaapEntities1();

        // GET: USUARIO
        public ActionResult Index()
        {
            return View(db.USUARIO.ToList());
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,NOMBRES,APELLIDOS,EMAIL,USUARIO1,CLAVE,FECHA_CREACION,FECHA_MODIFICACION")] USUARIO uSUARIO, string Clave2)
        {
            
            var max = db.USUARIO.OrderByDescending(x => x.ID_USUARIO).FirstOrDefault();
            if (max != null)
                uSUARIO.ID_USUARIO = max.ID_USUARIO + 1;
            else
                uSUARIO.ID_USUARIO = 1;
            if (!uSUARIO.CLAVE.Equals(Clave2))
                throw new ApplicationException("Clave no coincide");
            else
            {
                uSUARIO.CLAVE = Util.Util.Encriptar(uSUARIO.CLAVE);
                uSUARIO.FECHA_CREACION = DateTime.Now;
                //validar contraseñas
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
            }
                
                return Redirect("~/default.aspx");
            
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,NOMBRES,APELLIDOS,EMAIL,USUARIO1,CLAVE,FECHA_CREACION,FECHA_MODIFICACION")] USUARIO uSUARIO, string Clave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;                
                uSUARIO.CLAVE = Clave;
                uSUARIO.FECHA_MODIFICACION = DateTime.Now;
                db.SaveChanges();
                
                return RedirectToAction("Index","Home");
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
