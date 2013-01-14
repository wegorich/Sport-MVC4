using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class TeamController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Team/

        public ActionResult Index()
        {
            return View(_db.Team.ToList());
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            SetUpViewData();
            return View(new Team());
        }

        //
        // POST: /Team/Create

        [HttpPost]
        public ActionResult Create(Team team, int[] memebersm, int[] eventsm)
        {
            if (team != null)
            {
                EditListItems(team, memebersm, eventsm);

                _db.Team.Add(team);
                _db.SaveChanges();
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");

            SetUpViewData();
            return View(new Team());
        }

        private void EditListItems(Team team, int[] memebersm, int[] eventsm)
        {
            if (memebersm != null && memebersm.Length > 0)
            {
                var sportsmans = _db.Sportsmans.Where(x => x.Team.Id == team.Id);
                foreach (var item in sportsmans)
                {
                    item.Team = null;
                }
                team.Memebers = new List<Sportsman>();
                foreach (var item in _db.Sportsmans.Where(x => memebersm.Contains(x.Id)))
                {
                    team.Memebers.Add(item);
                }
            }

            if (eventsm != null && eventsm.Length > 0)
            {
                var ev = _db.Events.Where(x => x.Teams.Any(i => i.Id == team.Id));
                foreach (var item in ev)
                {
                    item.Teams.Remove(team);
                }
                team.Events = new List<Event>();
                foreach (var item in _db.Events.Where(x => eventsm.Contains(x.Id)))
                {
                    team.Events.Add(item);
                }
            }
        }

        //
        // GET: /Team/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Team team = _db.Team.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            SetUpViewData();
            return View("Create", team);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team, int[] memebersm, int[] eventsm)
        {
            if (team != null)
            {
                _db.Entry(team).State = EntityState.Modified;
                _db.SaveChanges();

                EditListItems(team, memebersm, eventsm);

                _db.SaveChanges();
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }

            SetUpViewData();
            return View("Create", new Team());
        }

        private void SetUpViewData()
        {
            ViewData["Eventsmultiple"] = _db.Events.ToArray();
            ViewData["Memebersmultiple"] = _db.Sportsmans.Where(x => x.Team == null).ToArray();
        }

        //
        // GET: /Team/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Team entity = _db.Team.Find(id);
            if (entity != null)
            {
                entity.Memebers.Clear();
                entity.Events.Clear();
                _db.Team.Remove(entity);
                _db.SaveChanges();
                Information("Your Team was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = _db.Team.Find(id);
            _db.Team.Remove(team);
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