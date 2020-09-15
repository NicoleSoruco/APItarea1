using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adminNicole.Models;

namespace adminNicole.Controllers
{
    public class SorucoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Sorucoes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Sorucoes.ToList());
        }

        // GET: Sorucoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soruco soruco = db.Sorucoes.Find(id);
            if (soruco == null)
            {
                return HttpNotFound();
            }
            return View(soruco);
        }

        // GET: Sorucoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sorucoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SorucoID,FriendofSoruco,Place,Email,Birthdayt")] Soruco soruco)
        {
            if (ModelState.IsValid)
            {
                db.Sorucoes.Add(soruco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soruco);
        }

        // GET: Sorucoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soruco soruco = db.Sorucoes.Find(id);
            if (soruco == null)
            {
                return HttpNotFound();
            }
            return View(soruco);
        }

        // POST: Sorucoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SorucoID,FriendofSoruco,Place,Email,Birthdayt")] Soruco soruco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soruco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soruco);
        }

        // GET: Sorucoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soruco soruco = db.Sorucoes.Find(id);
            if (soruco == null)
            {
                return HttpNotFound();
            }
            return View(soruco);
        }

        // POST: Sorucoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soruco soruco = db.Sorucoes.Find(id);
            db.Sorucoes.Remove(soruco);
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
