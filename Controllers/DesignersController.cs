﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicStore.Models;

namespace ComicStore.Controllers
{
    public class DesignersController : Controller
    {
        private ComicStoreContext db = new ComicStoreContext();

        // GET: Designers
        public ActionResult Index()
        {
            return View(db.Designers.ToList());
        }

        // GET: Designers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // GET: Designers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignerId,Name,Company,Established")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                db.Designers.Add(designer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designer);
        }

        // GET: Designers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: Designers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignerId,Name,Company,Established")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designer);
        }

        // GET: Designers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designer designer = db.Designers.Find(id);
            db.Designers.Remove(designer);
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
