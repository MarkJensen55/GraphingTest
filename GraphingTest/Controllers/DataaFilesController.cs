using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraphingTest.Models;

namespace GraphingTest
{
    public class DataaFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DataaFiles
        public ActionResult Index()
        {
            return View(db.DataaFiles.ToList());
        }

        // GET: DataaFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataaFile dataaFile = db.DataaFiles.Find(id);
            if (dataaFile == null)
            {
                return HttpNotFound();
            }
            return View(dataaFile);
        }

        // GET: DataaFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataaFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DataaFileID,EntryDate,Value")] DataaFile dataaFile)
        {
            if (ModelState.IsValid)
            {
                db.DataaFiles.Add(dataaFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataaFile);
        }

        //GET: 
        public ActionResult Graph()
        {
            var data = from d in db.DataaFiles
                       select d;
            data = data.OrderBy(d => d.EntryDate);
            var xdata = data.Select(x => x.EntryDate).ToArray();
            var ydata = data.AsEnumerable().Select(y => new object[] { y.Value }).ToArray(); 

            var ViewGraph = new TestChart();
            var ViewGraph2 = ViewGraph.CreateChart(xdata, ydata);

            return View(ViewGraph2);
        }

        // GET: DataaFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataaFile dataaFile = db.DataaFiles.Find(id);
            if (dataaFile == null)
            {
                return HttpNotFound();
            }
            return View(dataaFile);
        }

        // POST: DataaFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DataaFileID,EntryDate,Value")] DataaFile dataaFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataaFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataaFile);
        }

        // GET: DataaFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataaFile dataaFile = db.DataaFiles.Find(id);
            if (dataaFile == null)
            {
                return HttpNotFound();
            }
            return View(dataaFile);
        }

        // POST: DataaFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataaFile dataaFile = db.DataaFiles.Find(id);
            db.DataaFiles.Remove(dataaFile);
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
