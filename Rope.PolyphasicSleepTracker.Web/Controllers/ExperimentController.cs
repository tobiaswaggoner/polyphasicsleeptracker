using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rope.PolyphasicSleepTracker.Web.Models.Tracking;
using Rope.PolyphasicSleepTracker.Web.Models;

namespace Rope.PolyphasicSleepTracker.Web.Controllers
{
    public class ExperimentController : Controller
    {
        private SleepTrackerContext db = new SleepTrackerContext();

        //
        // GET: /Experiment/

        public ActionResult Index()
        {
            var experiments = db.Experiments.Include(e => e.User);
            return View(experiments.ToList());
        }

        //
        // GET: /Experiment/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            return View(experiment);
        }

        //
        // GET: /Experiment/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Experiment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                experiment.ExperimentPK = Guid.NewGuid();
                db.Experiments.Add(experiment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", experiment.UserId);
            return View(experiment);
        }

        //
        // GET: /Experiment/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", experiment.UserId);
            return View(experiment);
        }

        //
        // POST: /Experiment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", experiment.UserId);
            return View(experiment);
        }

        //
        // GET: /Experiment/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            return View(experiment);
        }

        //
        // POST: /Experiment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Experiment experiment = db.Experiments.Find(id);
            db.Experiments.Remove(experiment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}