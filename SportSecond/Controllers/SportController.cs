using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class SportController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Sport/

        public ActionResult Index()
        {
            return View(_db.Sport.ToList());
        }

        //
        // GET: /Sport/Details/5

        public ActionResult Details(int id = 0)
        {
            Sport sport = _db.Sport.Find(id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        //
        // GET: /Sport/Create

        public ActionResult Create()
        {
            return View(new Sport());
        }

        //
        // POST: /Sport/Create

        [HttpPost]
        public ActionResult Create(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _db.Sport.Add(sport);
                _db.SaveChanges();
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(sport);
        }

        //
        // GET: /Sport/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sport sport = _db.Sport.Find(id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View("Create", sport);
        }

        //
        // POST: /Sport/Edit/5

        [HttpPost]
        public ActionResult Edit(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sport).State = EntityState.Modified;
                _db.SaveChanges();
                Success("The model was updated!");

                return RedirectToAction("Index");
            }
            return View("Create", sport);
        }

        //
        // GET: /Sport/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sport entity = _db.Sport.Find(id);
            if (entity != null)
            {
                _db.Sport.Remove(entity);
                _db.SaveChanges();
                Information("Your sport was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Sport/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sport sport = _db.Sport.Find(id);
            _db.Sport.Remove(sport);
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