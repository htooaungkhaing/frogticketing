using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrogProject;

namespace FrogProject.Controllers
{
    public class eventdetailsController : Controller
    {
        private frogprojectEntities db = new frogprojectEntities();

        // GET: eventdetails
        public ActionResult Index()
        {
            return View(db.eventdetails.ToList());
        }
        public ActionResult deleteevent()
        {
            return View(db.eventdetails.ToList());
        }

        // GET: eventdetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventdetail eventdetail = db.eventdetails.Find(id);
            if (eventdetail == null)
            {
                return HttpNotFound();
            }
            return View(eventdetail);
        }

        // GET: eventdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventName,Type,Venue,Lng,Lat,Date,Time,GateOpen,PublicSale,valiabeTicet,Price")] eventdetail eventdetail)
        {
            if (ModelState.IsValid)
            {
                eventdetail.EventID = Guid.NewGuid();
                db.eventdetails.Add(eventdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventdetail);
        }

        // GET: eventdetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventdetail eventdetail = db.eventdetails.Find(id);
            if (eventdetail == null)
            {
                return HttpNotFound();
            }
            return View(eventdetail);
        }

        // POST: eventdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Type,Venue,Lng,Lat,Date,Time,GateOpen,PublicSale,valiabeTicet,Price")] eventdetail eventdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("deleteevent");
            }
            return View(eventdetail);
        }

        // GET: eventdetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventdetail eventdetail = db.eventdetails.Find(id);
            if (eventdetail == null)
            {
                return HttpNotFound();
            }
            return View(eventdetail);
        }

        // POST: eventdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            eventdetail eventdetail = db.eventdetails.Find(id);
            db.eventdetails.Remove(eventdetail);
            db.SaveChanges();
            return RedirectToAction("deleteevent");
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
