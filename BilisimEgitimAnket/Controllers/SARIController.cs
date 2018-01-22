using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilisimEgitimAnket.Models;

namespace BilisimEgitimAnket.Controllers
{
    public class SARIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SARI
        public async Task<ActionResult> Index()
        {
            var sariler = db.Sariler.Include(s => s.Kelime);
            return View(await sariler.ToListAsync());
        }

        // GET: SARI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SARI sARI = await db.Sariler.FindAsync(id);
            if (sARI == null)
            {
                return HttpNotFound();
            }
            return View(sARI);
        }

        // GET: SARI/Create
        public ActionResult Create()
        {
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI");
            return View();
        }

        // POST: SARI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] SARI sARI)
        {
            if (ModelState.IsValid)
            {
                db.Sariler.Add(sARI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", sARI.GID);
            return View(sARI);
        }

        // GET: SARI/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SARI sARI = await db.Sariler.FindAsync(id);
            if (sARI == null)
            {
                return HttpNotFound();
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", sARI.GID);
            return View(sARI);
        }

        // POST: SARI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] SARI sARI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sARI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", sARI.GID);
            return View(sARI);
        }

        // GET: SARI/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SARI sARI = await db.Sariler.FindAsync(id);
            if (sARI == null)
            {
                return HttpNotFound();
            }
            return View(sARI);
        }

        // POST: SARI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SARI sARI = await db.Sariler.FindAsync(id);
            db.Sariler.Remove(sARI);
            await db.SaveChangesAsync();
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
