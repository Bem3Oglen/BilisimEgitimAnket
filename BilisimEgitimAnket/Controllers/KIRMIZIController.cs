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
    public class KIRMIZIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KIRMIZI
        public async Task<ActionResult> Index()
        {
            var kirmiziler = db.Kirmiziler.Include(k => k.Kelime);
            return View(await kirmiziler.ToListAsync());
        }

        // GET: KIRMIZI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIRMIZI kIRMIZI = await db.Kirmiziler.FindAsync(id);
            if (kIRMIZI == null)
            {
                return HttpNotFound();
            }
            return View(kIRMIZI);
        }

        // GET: KIRMIZI/Create
        public ActionResult Create()
        {
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI");
            return View();
        }

        // POST: KIRMIZI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] KIRMIZI kIRMIZI)
        {
            if (ModelState.IsValid)
            {
                db.Kirmiziler.Add(kIRMIZI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", kIRMIZI.GID);
            return View(kIRMIZI);
        }

        // GET: KIRMIZI/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIRMIZI kIRMIZI = await db.Kirmiziler.FindAsync(id);
            if (kIRMIZI == null)
            {
                return HttpNotFound();
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", kIRMIZI.GID);
            return View(kIRMIZI);
        }

        // POST: KIRMIZI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] KIRMIZI kIRMIZI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kIRMIZI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", kIRMIZI.GID);
            return View(kIRMIZI);
        }

        // GET: KIRMIZI/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIRMIZI kIRMIZI = await db.Kirmiziler.FindAsync(id);
            if (kIRMIZI == null)
            {
                return HttpNotFound();
            }
            return View(kIRMIZI);
        }

        // POST: KIRMIZI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KIRMIZI kIRMIZI = await db.Kirmiziler.FindAsync(id);
            db.Kirmiziler.Remove(kIRMIZI);
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
