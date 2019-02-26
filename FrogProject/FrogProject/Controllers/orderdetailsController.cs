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
    public class orderdetailsController : Controller
    {
        private frogprojectEntities db = new frogprojectEntities();

        // GET: orderdetails
        public ActionResult Index(int total,string vid)
        {
            var orderdetails = db.orderdetails.Include(o => o.AspNetUser).Include(o => o.eventdetail);
            if (total == 0)
            {
                ViewBag.total = "";
            }
            else if (vid == null)
            {
                ViewBag.vid = "";
            }
            else
            {
                ViewBag.total = total;
                ViewBag.vid = vid;
                return View(orderdetails.ToList());
            }
            return View(orderdetails.ToList());
        }

        // GET: orderdetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderdetail orderdetail = db.orderdetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }





        // GET: orderdetails/Create
        public ActionResult Create(string text)
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "EventName");
            if (User.Identity.GetUserId() == null)
            {
                ViewBag.Eventprice = 123;
            }
            else
            {
                ViewBag.Eventprice = new SelectList(db.eventdetails, "Price", "EventName");
            }
            ViewBag.Eventqty = new SelectList(db.eventdetails, "valiabeTicet", "EventName");
            //ViewBag.names = text;
            ViewBag.Total = 0;
            ViewBag.id = "";
            return View();
        }

        // POST: orderdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ([Bind(Include = "VoucherID,EventName,Quantity,Name,Phone,SecondPhone,Address,Email,PostalCode")] orderdetail orderdetail)
        {
            if (User.Identity.GetUserId() == null)
            {                                                               
                ModelState.AddModelError("Error", "Please Login First to Order!");
                ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "EventName");
                return View();
            }
          else if (ModelState.IsValid)
            {
                orderdetail.VoucherID = Guid.NewGuid();
                orderdetail.UserID = User.Identity.GetUserId();
                int qty = orderdetail.Quantity;
                var y = db.eventdetails.Where(t => t.EventName == orderdetail.EventName).FirstOrDefault();
                if (y != null)
                {
                    if (y.valiabeTicet == 0)
                    {
                        string text = "Ticket Sold Out";
                        ModelState.AddModelError("Error", text);
                        ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "EventName");
                        return View();
                        //return RedirectToAction("Create", "orderdetails", new { text });
                    }
                    else if (y.valiabeTicet < qty)
                    {
                        string text = "Not enough ticket. Only "+y.valiabeTicet+" left.";
                        ModelState.AddModelError("Error", text);
                        ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "EventName");
                        return View();
                        //return RedirectToAction("Create", "orderdetails", new { text });
                    }
                    else
                    {
                    y.valiabeTicet = y.valiabeTicet - qty;
                        db.SaveChanges();
                    }
                }
                db.orderdetails.Add(orderdetail);
                db.SaveChanges();
                int price = int.Parse(y.Price);
                int total = price * qty;
                string vid = orderdetail.VoucherID.ToString();
                return RedirectToAction("Index","orderdetails",new {total,vid});
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", orderdetail.UserID);
            ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "Type", orderdetail.EventName);

            return View(orderdetail);           
        }

        // GET: orderdetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderdetail orderdetail = db.orderdetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", orderdetail.UserID);
            ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "Type", orderdetail.EventName);
            return View(orderdetail);
        }

        // POST: orderdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherID,UserID,EventName,Quantity,Name,Phone,SecondPhone,Address,Email,PostalCode")] orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", orderdetail.UserID);
            ViewBag.EventName = new SelectList(db.eventdetails, "EventName", "Type", orderdetail.EventName);
            return View(orderdetail);
        }

        // GET: orderdetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderdetail orderdetail = db.orderdetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // POST: orderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            orderdetail orderdetail = db.orderdetails.Find(id);
            db.orderdetails.Remove(orderdetail);
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
