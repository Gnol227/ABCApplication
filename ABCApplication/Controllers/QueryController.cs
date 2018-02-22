using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace ABCApplication.Controllers
{
    public class QueryController : BaseController
    {
        private ABCApplicationDbContext db = new ABCApplicationDbContext();

        // GET: Admin/Query
        public ActionResult Index()
        {
            return View(db.Queries.ToList());
        }

        // GET: Admin/Query/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // GET: Admin/Query/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Query/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Question")] Query query)
        {
            if (ModelState.IsValid)
            {
                db.Queries.Add(query);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(query);
        }

        // GET: Admin/Query/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Admin/Query/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Question,Status")] Query query)
        {
            if (ModelState.IsValid)
            {
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(query);
        }

        // GET: Admin/Query/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Admin/Query/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Query query = db.Queries.Find(id);
            db.Queries.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //ChangeStatus method which return Json type for ajax call
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            Query query = db.Queries.Find(id);
            query.Status = !query.Status;
            db.SaveChanges();
            return Json(new
            {
                status = query.Status
            });

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
