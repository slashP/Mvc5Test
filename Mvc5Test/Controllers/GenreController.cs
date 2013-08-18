using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Test.Models;

namespace Mvc5Test.Controllers
{
    public class GenreController : Controller
    {
        private IdentityDbContext db = new IdentityDbContext();

        //
        // GET: /Genre/
        public ActionResult Index()
        {
            return View(db.Genre.ToList());
        }

        //
        // GET: /Genre/Details/5
        public ActionResult Details(Int32 id)
        {
            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // GET: /Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genre.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        //
        // GET: /Genre/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /Genre/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Genre genre = db.Genre.Find(id);
            db.Genre.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
