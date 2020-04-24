using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaringSquareApp.Models;

namespace CaringSquareApp.Controllers
{
    public class POIsController : Controller
    {
        private CaringSquareEntities db = new CaringSquareEntities();

        // GET: POIs
        public ActionResult Index()
        {
            return View(db.POIs.ToList());
        }

        public ActionResult Shopping()
        {
            var shoppingLists = db.POIs.Where(s => s.Category == "shopping").ToList();
            return View(shoppingLists);
        }

        // GET: POIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POIs pOIs = db.POIs.Find(id);
            if (pOIs == null)
            {
                return HttpNotFound();
            }
            return View(pOIs);
        }

        // GET: POIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceId,Name,Theme,SubTheme,Address,Latitude,Longitude,Category")] POIs pOIs)
        {
            if (ModelState.IsValid)
            {
                db.POIs.Add(pOIs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOIs);
        }

        // GET: POIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POIs pOIs = db.POIs.Find(id);
            if (pOIs == null)
            {
                return HttpNotFound();
            }
            return View(pOIs);
        }

        // POST: POIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceId,Name,Theme,SubTheme,Address,Latitude,Longitude,Category")] POIs pOIs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOIs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOIs);
        }

        // GET: POIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POIs pOIs = db.POIs.Find(id);
            if (pOIs == null)
            {
                return HttpNotFound();
            }
            return View(pOIs);
        }

        // POST: POIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POIs pOIs = db.POIs.Find(id);
            db.POIs.Remove(pOIs);
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
