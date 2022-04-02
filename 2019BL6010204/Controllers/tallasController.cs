using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2019BL6010204;

namespace _2019BL6010204.Controllers
{
    public class tallasController : Controller
    {
        private shositodbEntities db = new shositodbEntities();

        // GET: tallas
        public ActionResult Index()
        {
            return View(db.tallas.ToList());
        }

        // GET: tallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talla talla = db.tallas.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // GET: tallas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_talla,talla1,estado")] talla talla)
        {
            if (ModelState.IsValid)
            {
                db.tallas.Add(talla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talla);
        }

        // GET: tallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talla talla = db.tallas.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // POST: tallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_talla,talla1,estado")] talla talla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talla);
        }

        // GET: tallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talla talla = db.tallas.Find(id);
            if (talla == null)
            {
                return HttpNotFound();
            }
            return View(talla);
        }

        // POST: tallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            talla talla = db.tallas.Find(id);
            db.tallas.Remove(talla);
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
