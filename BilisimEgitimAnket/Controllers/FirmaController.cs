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
    public class FirmaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Firma
        public async Task<ActionResult> Index()
        {
            return View(await db.Firmalar.ToListAsync());
        }

        // GET: Firma/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = await db.Firmalar.FindAsync(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // GET: Firma/Create
        public ActionResult Create()
        {
            var firma = new Firma();
            return View(firma);
        }

        // POST: Firma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FADI,FADRES,YETKILI,TEL1,TEL2,GSM,FAKS,EMAIL,ACIKLAMA,OTAR,GTAR")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                firma.OTAR = DateTime.Now;
                firma.GTAR = DateTime.Now;
                db.Firmalar.Add(firma);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(firma);
        }

        // GET: Firma/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = await db.Firmalar.FindAsync(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: Firma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FADI,FADRES,YETKILI,TEL1,TEL2,GSM,FAKS,EMAIL,ACIKLAMA,OTAR,GTAR")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                firma.GTAR = DateTime.Now;
                db.Entry(firma).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(firma);
        }

        // GET: Firma/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = await db.Firmalar.FindAsync(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: Firma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Firma firma = await db.Firmalar.FindAsync(id);
            db.Firmalar.Remove(firma);
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
