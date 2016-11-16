using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class checkoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: checkouts
        public ActionResult Index()
        {
            var checkouts = db.checkouts.Include(c => c.book).Include(c => c.manager).Include(c => c.student);
            return View(checkouts.ToList());
        }

        // GET: checkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout checkout = db.checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            return View(checkout);
        }

        // GET: checkouts/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.books, "bookID", "bookName");
            ViewBag.managerID = new SelectList(db.managers, "managerID", "managerName");
            ViewBag.studentID = new SelectList(db.students, "studentID", "studentName");
            return View();
        }

        // POST: checkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "checkoutID,bookID,studentID,managerID,checkoutDate,returnDate")] checkout checkout)
        {
            if (ModelState.IsValid)
            {
                db.checkouts.Add(checkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.books, "bookID", "bookName", checkout.bookID);
            ViewBag.managerID = new SelectList(db.managers, "managerID", "managerName", checkout.managerID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "studentName", checkout.studentID);
            return View(checkout);
        }

        // GET: checkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout checkout = db.checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.books, "bookID", "bookName", checkout.bookID);
            ViewBag.managerID = new SelectList(db.managers, "managerID", "managerName", checkout.managerID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "studentName", checkout.studentID);
            return View(checkout);
        }

        // POST: checkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "checkoutID,bookID,studentID,managerID,checkoutDate,returnDate")] checkout checkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.books, "bookID", "bookName", checkout.bookID);
            ViewBag.managerID = new SelectList(db.managers, "managerID", "managerName", checkout.managerID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "studentName", checkout.studentID);
            return View(checkout);
        }

        // GET: checkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout checkout = db.checkouts.Find(id);
            if (checkout == null)
            {
                return HttpNotFound();
            }
            return View(checkout);
        }

        // POST: checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            checkout checkout = db.checkouts.Find(id);
            db.checkouts.Remove(checkout);
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
