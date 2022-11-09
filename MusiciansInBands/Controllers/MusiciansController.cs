using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusiciansInBands.Models;

namespace MusiciansInBands.Controllers
{
    public class MusiciansController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Musicians
        public ActionResult Index()
        {
            var musicians = db.Musicians.Include(m => m.Band).Include(m => m.Instrument);
            return View(musicians.ToList());
        }

        // GET: Musicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            musician = db.Musicians.Include(m => m.Band).FirstOrDefault(b => b.Id == id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        public FileContentResult GetImage(int id)
        {
            Musician musician = db.Musicians.FirstOrDefault(g => g.Id == id);
            if (musician != null)
            {
                return File(musician.Photo, musician.PhotoType);
            }
            return null;
        }

        // GET: Musicians/Create
        public ActionResult Create()
        {
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name");
            ViewBag.InstrumentId = new SelectList(db.Instruments, "Id", "Name");
            return View();
        }

        // POST: Musicians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Surname,Age,Photo,PhotoType,InstrumentId,BandId")] Musician musician, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    musician.PhotoType = Image.ContentType;
                    musician.Photo = new byte[Image.ContentLength];
                    Image.InputStream.Read(musician.Photo, 0, Image.ContentLength);
                }
                db.Musicians.Add(musician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name", musician.BandId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "Id", "Name", musician.InstrumentId);
            return View(musician);
        }

        // GET: Musicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name", musician.BandId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "Id", "Name", musician.InstrumentId);
            return View(musician);
        }

        // POST: Musicians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Surname,Age,Photo,PhotoType,InstrumentId,BandId")] Musician musician, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    musician.PhotoType = Image.ContentType;
                    musician.Photo = new byte[Image.ContentLength];
                    Image.InputStream.Read(musician.Photo, 0, Image.ContentLength);
                }
                db.Entry(musician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name", musician.BandId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "Id", "Name", musician.InstrumentId);
            return View(musician);
        }

        // GET: Musicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: Musicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musician musician = db.Musicians.Find(id);
            db.Musicians.Remove(musician);
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
