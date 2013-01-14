using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class LocationController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Location/

        public ActionResult Index()
        {
            return View(_db.Locations.ToList());
        }

        //
        // GET: /Location/Details/5

        public ActionResult Details(int id = 0)
        {
            Location location = _db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            ViewData["Country"] = _db.Countries.ToArray();
            return View(new Location());
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(Location location, int country)
        {
            if (location != null)
            {
                Country item = _db.Countries.FirstOrDefault(x => x.Id == country);
                if (item != null)
                {
                    location.Country = item;
                    _db.Locations.Add(location);
                    _db.SaveChanges();
                    Success("Your information was saved!");
                    return RedirectToAction("Index");
                }
            }
            Error("there were some errors in your form.");
            ViewData["Country"] = _db.Countries.ToArray();
            return View(location);
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Location location = _db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewData["Country"] = _db.Countries.ToArray();
            return View("Create", location);
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(Location location, int country)
        {
            if (location != null)
            {
                _db.Entry(location).State = EntityState.Modified;
                _db.SaveChanges();

                Country item = _db.Countries.FirstOrDefault(x => x.Id == country);
                if (item != null)
                {
                    location = _db.Locations.First(x => x.Id == location.Id);
                    location.Country = item;
                    _db.SaveChanges();
                }
                Success("The model was updated!");
                return RedirectToAction("Index");
            }
            ViewData["Country"] = _db.Countries.ToArray();
            return View("Create", location);
        }

        //
        // GET: /Location/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Location entity = _db.Locations.Find(id);
            if (entity != null)
            {
                _db.Locations.Remove(entity);
                _db.SaveChanges();
                Information("Your location was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Location/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = _db.Locations.Find(id);
            _db.Locations.Remove(location);
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