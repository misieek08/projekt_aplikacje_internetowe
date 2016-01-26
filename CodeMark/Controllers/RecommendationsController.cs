using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeMark.Models;

namespace CodeMark.Controllers
{
    public class RecommendationsController : Controller
    {
        private CodeMarkContext db = new CodeMarkContext();

        // GET: Recommendations
        public ActionResult Index()
        {
            return View(db.Recommendations.ToList());
        }

       
        // GET: Recommendations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recommendations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Recommendation recommendation, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    recommendation.Content = reader.ReadBytes(upload.ContentLength);
                }
                db.Recommendations.Add(recommendation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recommendation);
        }

        // POST: Recommendations/Delete/5
        //[HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Recommendation recommendation = db.Recommendations.Find(id);
            db.Recommendations.Remove(recommendation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileResult RecommendationPreview(int id)
        {
            Recommendation recommendation = db.Recommendations.Find(id);
            return File(recommendation.Content, "image/jpeg");
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
