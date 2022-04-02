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
    public class colorsController : Controller
    {
        private shositodbEntities db = new shositodbEntities();

        // GET: colors
        public ActionResult Index()
        {
            return View(db.colors.ToList());
        }

        // GET: colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: colors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: colors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_color,color1,estado")] color color)
        {
            if (ModelState.IsValid)
            {
                db.colors.Add(color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(color);
        }

        // GET: colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: colors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_color,color1,estado")] color color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(color);
        }

        // GET: colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            color color = db.colors.Find(id);
            db.colors.Remove(color);
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
