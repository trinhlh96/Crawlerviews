using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrawlerView.Data;
using CrawlerView.Models;

namespace CrawlerView.Controllers
{
    public class CrawlersController : Controller
    {
        private CrawlerViewContext db = new CrawlerViewContext();

        // GET: Crawlers
        public ActionResult Index()
        {
            return View(db.Crawlers.ToList());
        }

        // GET: Crawlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crawler crawler = db.Crawlers.Find(id);
            if (crawler == null)
            {
                return HttpNotFound();
            }
            return View(crawler);
        }

        // GET: Crawlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crawlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Image,Description,Link")] Crawler crawler)
        {
            if (ModelState.IsValid)
            {
                db.Crawlers.Add(crawler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crawler);
        }

        // GET: Crawlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crawler crawler = db.Crawlers.Find(id);
            if (crawler == null)
            {
                return HttpNotFound();
            }
            return View(crawler);
        }

        // POST: Crawlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Image,Description,Link")] Crawler crawler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crawler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crawler);
        }

        // GET: Crawlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crawler crawler = db.Crawlers.Find(id);
            if (crawler == null)
            {
                return HttpNotFound();
            }
            return View(crawler);
        }

        // POST: Crawlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crawler crawler = db.Crawlers.Find(id);
            db.Crawlers.Remove(crawler);
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
