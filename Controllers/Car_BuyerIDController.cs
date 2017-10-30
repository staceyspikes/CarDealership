using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class Car_BuyerIDController : Controller
    {
        private CarDelearshipDBEntities db = new CarDelearshipDBEntities();

        // GET: Car_BuyerID
        public ActionResult Index()
        {
            var car_BuyerID = db.Car_BuyerID.Include(c => c.Buyer).Include(c => c.Car);
            return View(car_BuyerID.ToList());
        }

        // GET: Car_BuyerID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_BuyerID car_BuyerID = db.Car_BuyerID.Find(id);
            if (car_BuyerID == null)
            {
                return HttpNotFound();
            }
            return View(car_BuyerID);
        }

        // GET: Car_BuyerID/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName");
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber");
            return View();
        }

        // POST: Car_BuyerID/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_BuyerID1,CarID,BuyerID")] Car_BuyerID car_BuyerID)
        {
            if (ModelState.IsValid)
            {
                db.Car_BuyerID.Add(car_BuyerID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_BuyerID.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_BuyerID.CarID);
            return View(car_BuyerID);
        }

        // GET: Car_BuyerID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_BuyerID car_BuyerID = db.Car_BuyerID.Find(id);
            if (car_BuyerID == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_BuyerID.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_BuyerID.CarID);
            return View(car_BuyerID);
        }

        // POST: Car_BuyerID/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Car_BuyerID1,CarID,BuyerID")] Car_BuyerID car_BuyerID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_BuyerID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_BuyerID.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_BuyerID.CarID);
            return View(car_BuyerID);
        }

        // GET: Car_BuyerID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_BuyerID car_BuyerID = db.Car_BuyerID.Find(id);
            if (car_BuyerID == null)
            {
                return HttpNotFound();
            }
            return View(car_BuyerID);
        }

        // POST: Car_BuyerID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_BuyerID car_BuyerID = db.Car_BuyerID.Find(id);
            db.Car_BuyerID.Remove(car_BuyerID);
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
