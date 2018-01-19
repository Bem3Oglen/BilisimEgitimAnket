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
    [Authorize]
    public class KelimeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kelime
        public async Task<ActionResult> Index()
        {
            return View(await db.Kelimeler.ToListAsync());
        }

        public ActionResult Listele()
        {
            return View();
        }
        public ActionResult Kliste()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var kelimeler = db.Kelimeler.ToList();
            return Json(kelimeler, JsonRequestBehavior.AllowGet);
        }

        // GET: Kelime/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelime kelime = await db.Kelimeler.FindAsync(id);
            if (kelime == null)
            {
                return HttpNotFound();
            }
            return View(kelime);
        }

        // GET: Kelime/Create
        public ActionResult Create()
        {
            var kelime = new Kelime();
            try
            {
                var GrpNolar = (from s in db.Kelimeler
                                select s.GID).ToList();
                int grpSize = GrpNolar.Count();
                int num = 1;
                for (int i = 1; i <= grpSize; i++)
                {
                    if (GrpNolar.Contains(i))
                    {
                        num = grpSize + 1;
                    }
                    else if (GrpNolar.Contains(i)==false)
                    {
                        num = i;
                        break;
                    }
                }
                ViewBag.GID = num;
            }
            catch (Exception)
            {
                ViewBag.GID = 1;
            }
            return View(kelime);
        }

        // POST: Kelime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,GID,SARI,KIRMIZI,MAVI,YESIL,DURUM,OTAR,GTAR")] Kelime kelime)
        {
            if (ModelState.IsValid)
            {
                kelime.OTAR = DateTime.Now;
                kelime.GTAR = DateTime.Now;
                db.Kelimeler.Add(kelime);
                await db.SaveChangesAsync();
                return RedirectToAction("Listele");
            }

            return View(kelime);
        }

        // GET: Kelime/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelime kelime = await db.Kelimeler.FindAsync(id);
            if (kelime == null)
            {
                return HttpNotFound();
            }
            return View(kelime);
        }

        // POST: Kelime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,GID,SARI,KIRMIZI,MAVI,YESIL,DURUM,OTAR,GTAR")] Kelime kelime)
        {
            if (ModelState.IsValid)
            {
                kelime.GTAR = DateTime.Now;
                db.Entry(kelime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kelime);
        }

        // GET: Kelime/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelime kelime = await db.Kelimeler.FindAsync(id);
            if (kelime == null)
            {
                return HttpNotFound();
            }
            return View(kelime);
        }

        // POST: Kelime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kelime kelime = await db.Kelimeler.FindAsync(id);
            db.Kelimeler.Remove(kelime);
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
