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
    public class MAVIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MAVI
        public async Task<ActionResult> Index()
        {
            var maviler = db.Maviler.Include(m => m.Kelime);
            return View(await maviler.ToListAsync());
        }

        // GET: MAVI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAVI mAVI = await db.Maviler.FindAsync(id);
            if (mAVI == null)
            {
                return HttpNotFound();
            }
            return View(mAVI);
        }

        // GET: MAVI/Create
        public ActionResult Create()
        {
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI");
            return View();
        }

        // POST: MAVI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] MAVI mAVI)
        {
            if (ModelState.IsValid)
            {
                db.Maviler.Add(mAVI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", mAVI.GID);
            return View(mAVI);
        }

        // GET: MAVI/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAVI mAVI = await db.Maviler.FindAsync(id);
            if (mAVI == null)
            {
                return HttpNotFound();
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", mAVI.GID);
            return View(mAVI);
        }

        // POST: MAVI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] MAVI mAVI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAVI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", mAVI.GID);
            return View(mAVI);
        }

        // GET: MAVI/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAVI mAVI = await db.Maviler.FindAsync(id);
            if (mAVI == null)
            {
                return HttpNotFound();
            }
            return View(mAVI);
        }

        // POST: MAVI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MAVI mAVI = await db.Maviler.FindAsync(id);
            db.Maviler.Remove(mAVI);
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
