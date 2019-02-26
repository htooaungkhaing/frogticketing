using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrogProject;
using Microsoft.AspNet.Identity;

namespace FrogProject.Controllers
{
    public class feedbacksession1Controller : Controller
    {
        private frogprojectEntities db = new frogprojectEntities();

        // GET: feedbacksession1
        public ActionResult Index()
        {
            var feedbacksession1 = db.feedbacksession1.Include(f => f.AspNetUser);
            return View(feedbacksession1.ToList());
        }

        // GET: feedbacksession1/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbacksession1 feedbacksession1 = db.feedbacksession1.Find(id);
            if (feedbacksession1 == null)
            {
                return HttpNotFound();
            }
            return View(feedbacksession1);
        }

        // GET: feedbacksession1/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: feedbacksession1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Feedback")] feedbacksession1 feedbacksession1)
        {
            if (User.Identity.GetUserId() == null)
            {
                ModelState.AddModelError("Error", "Please Login First to give Feedback!");
                return View();
            }
            if (ModelState.IsValid)
            {
                     string mail = feedbacksession1.Email;
                    feedbacksession1.ID = Guid.NewGuid();
                    feedbacksession1.UserID = User.Identity.GetUserId();
                    db.feedbacksession1.Add(feedbacksession1);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", feedbacksession1.UserID);
            return View(feedbacksession1);
        }


        // GET: feedbacksession1/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbacksession1 feedbacksession1 = db.feedbacksession1.Find(id);
            if (feedbacksession1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", feedbacksession1.UserID);
            return View(feedbacksession1);
        }

        // POST: feedbacksession1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Email,Feedback")] feedbacksession1 feedbacksession1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbacksession1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", feedbacksession1.UserID);
            return View(feedbacksession1);
        }

        // GET: feedbacksession1/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedbacksession1 feedbacksession1 = db.feedbacksession1.Find(id);
            if (feedbacksession1 == null)
            {
                return HttpNotFound();
            }
            return View(feedbacksession1);
        }

        // POST: feedbacksession1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            feedbacksession1 feedbacksession1 = db.feedbacksession1.Find(id);
            db.feedbacksession1.Remove(feedbacksession1);
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
