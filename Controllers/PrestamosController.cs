﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrestamosBrito.DataBaseConection;
using PrestamosBrito.Models;

namespace PrestamosBrito.Content
{
    public class PrestamosController : Controller
    {
        private Conexion db = new Conexion();

        // GET: Prestamos
        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.Clientes);
            return View(prestamos.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.ClientesID = new SelectList(db.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,Tasa,Tiempo,ClientesID")] Prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientesID = new SelectList(db.Clientes, "Id", "Nombre", prestamos.ClientesID);
            return View(prestamos);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientesID = new SelectList(db.Clientes, "Id", "Nombre", prestamos.ClientesID);
            return View(prestamos);
        }

        // POST: Prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,Tasa,Tiempo,ClientesID")] Prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientesID = new SelectList(db.Clientes, "Id", "Nombre", prestamos.ClientesID);
            return View(prestamos);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamos);
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
