using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportSecond.Models;

namespace SportSecond.Controllers
{
    public class HomeController : BootstrapBaseController
    {
        private static readonly List<HomeInputModel> Models = ModelIntializer.CreateHomeInputModels();
        private readonly SportContext _db = new SportContext();

        public ActionResult Index()
        {
            var list = _db.Events.ToList();
            if (list.Count == 0)
            {
                Information("Нету событий! Совсем совсем...");
            }
            return View(list);
        }

        public ActionResult EventSearch(string search)
        {
            var list = _db.Events.Where(x=>x.Title.Contains(search)||x.Teams.Any(i=>i.Title.Contains(search))).ToList();
            if (list.Count == 0)
            {
                Information("Нету событий! Совсем совсем...");
            }
            return View("Index",list);
        }

        public ActionResult EventDetail(int id)
        {
            var item = _db.Events.Find(id);
            if (item == null)
            {
                Error("Такого события нету в нашей базе.");
            }
            return View(item);
        }

        public ActionResult Sportsmans()
        {
            var list = _db.Sportsmans.ToList();
            if (list.Count == 0)
            {
                Information("Нету ни одного спортсмена вокруг!");
            }
            return View(list);
        }

        public ActionResult SportsmansSearch(string search)
        {
            var list = _db.Sportsmans.Where(x=>x.Title.Contains(search)||x.Sport.Title.Contains(search)).ToList();
            if (list.Count == 0)
            {
                Information("Нету ни одного похожего спортсмена вокруг!");
            }
            return View("Sportsmans", list);
        }


        public ActionResult SportsmanDetail(int id)
        {
            var item = _db.Sportsmans.Find(id);
            if (item == null)
            {
                Error("Такого спортсмена нету в нашей базе.");
            }
            return View(item);
        }

        public ActionResult Teams()
        {
            var list = _db.Team.ToList();
            if (list.Count == 0)
            {
                Information("Нету ни одной похожей команды!");
            }
            return View(list);
        }

        public ActionResult TeamsSearch(string search)
        {
            var list = _db.Team.Where(x=>x.Title.Contains(search)||x.Memebers.Any(i => i.Title.Contains(search))).ToList();
            if (list.Count == 0)
            {
                Information("Нету ни одной похожей команды!");
            }
            return View("Teams", list);
        }

        public ActionResult TeamDetail(int id)
        {
            var item = _db.Team.Find(id);
            if (item == null)
            {
                Error("Такого команды нету в нашей базе.");
            }
            return View(item);
        }
        
        public ActionResult Edit(int id)
        {
            HomeInputModel model = Models.Get(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(HomeInputModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Models.Remove(Models.Get(id));
                model.Id = id;
                Models.Add(model);
                Success("The model was updated!");
                return RedirectToAction("index");
            }
            return View("Create", model);
        }

        public ActionResult Details(int id)
        {
            HomeInputModel model = Models.Get(id);
            return View(model);
        }
    }
}