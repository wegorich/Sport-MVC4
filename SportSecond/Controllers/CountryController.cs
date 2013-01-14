using System.Data;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class CountryController : BootstrapBaseController
    {
        private readonly SportContext _db = new SportContext();

        //
        // GET: /Country/

        public ActionResult Index()
        {
            return View(_db.Countries.ToList());
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id = 0)
        {
            Country country = _db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View(new Country());
        }

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(country);
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Country country = _db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View("Create", country);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(country).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", country);
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Country entity = _db.Countries.Find(id);
            if (entity != null)
            {
                _db.Countries.Remove(entity);
                _db.SaveChanges();
                Information("Your country was deleted");
            }
            if (!_db.Sport.Any())
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = _db.Countries.Find(id);
            _db.Countries.Remove(country);
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