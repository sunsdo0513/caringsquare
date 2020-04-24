using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaringSquareApp.Models;
using Microsoft.AspNet.Identity;

namespace CaringSquareApp.Controllers
{
    public class SocialEventsController : Controller
    {
        private CaringSquareEntities db = new CaringSquareEntities();

        // GET: SocialEvents
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var eventLists = db.SocialEvents.Where(s => s.UserUserId == userId).ToList();
            //var socialEvents = db.SocialEvents.Include(s => s.AspNetUser).Include(s => s.POIs);
            return View(eventLists);
        }

        // GET: SocialEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialEvent socialEvent = db.SocialEvents.Find(id);
            if (socialEvent == null)
            {
                return HttpNotFound();
            }
            return View(socialEvent);
        }

        // GET: SocialEvents/Create
        public ActionResult Create()
        {
            ViewBag.UserUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.POIPlaceId = new SelectList(db.POIs, "PlaceId", "Name");
            return View();
        }

        // POST: SocialEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,EventDate,EventTime,UserUserId,POIPlaceId")] SocialEvent socialEvent)
        {
            if (ModelState.IsValid)
            {
                db.SocialEvents.Add(socialEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserUserId = new SelectList(db.AspNetUsers, "Id", "Email", socialEvent.UserUserId);
            ViewBag.POIPlaceId = new SelectList(db.POIs, "PlaceId", "Name", socialEvent.POIPlaceId);
            return View(socialEvent);
        }

        // GET: SocialEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialEvent socialEvent = db.SocialEvents.Find(id);
            if (socialEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserUserId = new SelectList(db.AspNetUsers, "Id", "Email", socialEvent.UserUserId);
            ViewBag.POIPlaceId = new SelectList(db.POIs, "PlaceId", "Name", socialEvent.POIPlaceId);
            return View(socialEvent);
        }

        // POST: SocialEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,EventDate,EventTime,UserUserId,POIPlaceId")] SocialEvent socialEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserUserId = new SelectList(db.AspNetUsers, "Id", "Email", socialEvent.UserUserId);
            ViewBag.POIPlaceId = new SelectList(db.POIs, "PlaceId", "Name", socialEvent.POIPlaceId);
            return View(socialEvent);
        }

        // GET: SocialEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialEvent socialEvent = db.SocialEvents.Find(id);
            if (socialEvent == null)
            {
                return HttpNotFound();
            }
            return View(socialEvent);
        }

        // POST: SocialEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialEvent socialEvent = db.SocialEvents.Find(id);
            db.SocialEvents.Remove(socialEvent);
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
