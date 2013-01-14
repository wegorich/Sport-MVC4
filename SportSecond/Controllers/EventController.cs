using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class EventController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View(_db.Events.ToList());
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            ViewData["Location"] = _db.Locations.ToArray();
            ViewData["Teamsmultiple"] = _db.Team.ToArray();
            return View(new Event());
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(Event ev, int location, int[] teamsm)
        {
            if (ev != null && teamsm != null)
            {
                Location locationItem = _db.Locations.FirstOrDefault(x => x.Id == location);
                if (locationItem != null)
                {
                    EditListItems(ev,teamsm);
                    ev.Location = locationItem;
                    _db.Events.Add(ev);
                    _db.SaveChanges();
                    Success("Your information was saved!");
                    return RedirectToAction("Index");
                }
            }
            Error("there were some errors in your form.");
            ViewData["Location"] = _db.Locations.ToArray();
            ViewData["Teamsmultiple"] = _db.Team.ToArray();
            return View(ev);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event ev = _db.Events.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            ViewData["Location"] = _db.Locations.ToArray();
            ViewData["Teamsmultiple"] = _db.Team.ToArray();
            return View("Create", ev);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Event ev, int location, int[] teamsm)
        {
            if (ev != null)
            {
                _db.Entry(ev).State = EntityState.Modified;
                _db.SaveChanges();
                Location locationItem = _db.Locations.FirstOrDefault(x => x.Id == location);

                if (locationItem != null)
                {
                    EditListItems(ev, teamsm);

                    ev.Location = locationItem;
                    _db.SaveChanges();
                }
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            ViewData["Location"] = _db.Locations.ToArray();
            ViewData["Teamsmultiple"] = _db.Team.ToArray();
            return View("Create",new Event());
        }

        private void EditListItems(Event ev, int[] teamsm)
        {
            if (teamsm != null && teamsm.Length > 0)
            {
                var t = _db.Team.Where(x => x.Events.Any(i => i.Id == ev.Id));
                if (teamsm.Length == 0)
                    foreach (var item in t)
                    {
                        item.Events.Remove(ev);
                    }

                ev.Teams = new List<Team>();
                foreach (var item in _db.Team.Where(x => teamsm.Contains(x.Id)))
                {
                    ev.Teams.Add(item);
                }
            }
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event entity = _db.Events.Find(id);
            if (entity != null)
            {
                entity.Teams.Clear();
                _db.Events.Remove(entity);
                _db.SaveChanges();
                Information("Your Events was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event ev = _db.Events.Find(id);
            _db.Events.Remove(ev);
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