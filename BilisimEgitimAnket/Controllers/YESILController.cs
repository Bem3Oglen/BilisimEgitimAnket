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
    public class YESILController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YESIL
        public async Task<ActionResult> Index()
        {
            var yesiller = db.Yesiller.Include(y => y.Kelime);
            return View(await yesiller.ToListAsync());
        }

        // GET: YESIL/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YESIL yESIL = await db.Yesiller.FindAsync(id);
            if (yESIL == null)
            {
                return HttpNotFound();
            }
            return View(yESIL);
        }

        // GET: YESIL/Create
        public ActionResult Create()
        {
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI");
            return View();
        }

        // POST: YESIL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] YESIL yESIL)
        {
            if (ModelState.IsValid)
            {
                db.Yesiller.Add(yESIL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", yESIL.GID);
            return View(yESIL);
        }

        // GET: YESIL/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YESIL yESIL = await db.Yesiller.FindAsync(id);
            if (yESIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", yESIL.GID);
            return View(yESIL);
        }

        // POST: YESIL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,GID,SOZCUK,CUMLE1,CUMLE2,CUMLE3,OTAR,GTAR")] YESIL yESIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yESIL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GID = new SelectList(db.Kelimeler, "ID", "SARI", yESIL.GID);
            return View(yESIL);
        }

        // GET: YESIL/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YESIL yESIL = await db.Yesiller.FindAsync(id);
            if (yESIL == null)
            {
                return HttpNotFound();
            }
            return View(yESIL);
        }

        // POST: YESIL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            YESIL yESIL = await db.Yesiller.FindAsync(id);
            db.Yesiller.Remove(yESIL);
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
