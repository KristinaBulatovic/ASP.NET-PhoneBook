using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookWeb.Models;

namespace PhoneBookWeb.Controllers
{
    public class DataDirectoriesController : Controller
    {
        private PhoneBookEntities db = new PhoneBookEntities();

        // GET: DataDirectories
        public ActionResult Index(string searchBy, string search)
        {
            if (search != null && search != "")
            {
                if (searchBy == "FirstName")
                {
                    return View(db.DataDirectories.Where(x => x.FirstName == search).ToList());
                }
                else
                {
                    return View(db.DataDirectories.Where(x => x.LastName == search).ToList());
                }
            }
            else
            {
                return View(db.DataDirectories.ToList());
            }
 
        }

        // GET: DataDirectories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataDirectory dataDirectory = db.DataDirectories.Find(id);
            if (dataDirectory == null)
            {
                return HttpNotFound();
            }
            return View(dataDirectory);
        }

        // GET: DataDirectories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataDirectories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Telephone_Number")] DataDirectory dataDirectory)
        {
            if (ModelState.IsValid)
            {
                db.DataDirectories.Add(dataDirectory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataDirectory);
        }

        // GET: DataDirectories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataDirectory dataDirectory = db.DataDirectories.Find(id);
            if (dataDirectory == null)
            {
                return HttpNotFound();
            }
            return View(dataDirectory);
        }

        // POST: DataDirectories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Telephone_Number")] DataDirectory dataDirectory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataDirectory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataDirectory);
        }

        // GET: DataDirectories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataDirectory dataDirectory = db.DataDirectories.Find(id);
            if (dataDirectory == null)
            {
                return HttpNotFound();
            }
            return View(dataDirectory);
        }

        // POST: DataDirectories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataDirectory dataDirectory = db.DataDirectories.Find(id);
            db.DataDirectories.Remove(dataDirectory);
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
