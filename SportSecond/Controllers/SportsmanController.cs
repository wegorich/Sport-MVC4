using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class SportsmanController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Sportsman/

        public ActionResult Index()
        {
            return View(_db.Sportsmans.ToList());
        }

        //
        // GET: /Sportsman/Create

        public ActionResult Create()
        {
            SetUpViewData();
            return View(new Sportsman());
        }

        private void SetUpViewData()
        {
            ViewData["Nationality"] = _db.Nationalities.ToArray();
            ViewData["Sport"] = _db.Sport.ToArray();
            ViewData["Team"] = _db.Team.ToArray();
        }

        //
        // POST: /Sportsman/Create

        [HttpPost]
        public ActionResult Create(Sportsman sportsman, int nationality, int sport)
        {
            if (sportsman != null)
            {
                Nationality nationalityItem = _db.Nationalities.FirstOrDefault(x => x.Id == nationality);
                Sport sportItem = _db.Sport.FirstOrDefault(x => x.Id == sport);
                if (nationalityItem != null && sportItem != null)
                {
                    sportsman.Nationality = nationalityItem;
                    sportsman.Sport = sportItem;
                    _db.Sportsmans.Add(sportsman);
                    _db.SaveChanges();
                    Success("Your information was saved!");
                    return RedirectToAction("Index");
                }
            }
            Error("there were some errors in your form.");
            SetUpViewData();
            return View(sportsman);
        }

        //
        // GET: /Sportsman/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sportsman sportsman = _db.Sportsmans.Find(id);
            if (sportsman == null)
            {
                return HttpNotFound();
            }
            SetUpViewData();
            return View("Create", sportsman);
        }

        //
        // POST: /Sportsman/Edit/5

        [HttpPost]
        public ActionResult Edit(Sportsman sportsman, int nationality, int sport)
        {
            if (sportsman != null)
            {
                _db.Entry(sportsman).State = EntityState.Modified;
                _db.SaveChanges();

                Nationality nationalityItem = _db.Nationalities.FirstOrDefault(x => x.Id == nationality);
                Sport sportItem = _db.Sport.FirstOrDefault(x => x.Id == sport);
                if (nationalityItem != null && sportItem != null)
                {
                    sportsman = _db.Sportsmans.First(x => x.Id == sportsman.Id);
                    sportsman.Nationality = nationalityItem;
                    sportsman.Sport = sportItem;
                    _db.SaveChanges();
                }
                Success("Your information was saved!");
                return RedirectToAction("Index");
            } 
            SetUpViewData(); 
            return View("Create", new Sportsman());
        }

        //
        // GET: /Sportsman/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sportsman entity = _db.Sportsmans.Find(id);
            if (entity != null)
            {
                _db.Sportsmans.Remove(entity);
                _db.SaveChanges();
                Information("Your Sportsmans was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Sportsman/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sportsman sportsman = _db.Sportsmans.Find(id);
            _db.Sportsmans.Remove(sportsman);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}