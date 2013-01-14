using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SportSecond.App_Start;
using SportSecond.Models;

namespace SportSecond
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            IntializeDb();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapBundleConfig.RegisterBundles(BundleTable.Bundles);
            ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void IntializeDb()
        {
            //var dbContext = new SportContext().Database;
            //dbContext.Delete();
            Database.SetInitializer<SportContext>(null);

            try
            {
                using (var context = new SportContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter) context).ObjectContext.CreateDatabase();

                        #region Nationality damp

                        context.Nationalities.Add(new Nationality {Title = "абадзехи"});
                        context.Nationalities.Add(new Nationality {Title = "абаза"});
                        context.Nationalities.Add(new Nationality {Title = "абазины"});
                        context.Nationalities.Add(new Nationality {Title = "абжуйцы"});
                        context.Nationalities.Add(new Nationality {Title = "абхазы"});
                        context.Nationalities.Add(new Nationality {Title = "аварал"});
                        context.Nationalities.Add(new Nationality {Title = "аварцы"});
                        context.Nationalities.Add(new Nationality {Title = "австрийцы"});
                        context.Nationalities.Add(new Nationality {Title = "агинцы"});
                        context.Nationalities.Add(new Nationality {Title = "агул шуй"});
                        context.Nationalities.Add(new Nationality {Title = "агулар"});
                        context.Nationalities.Add(new Nationality {Title = "агульцы"});
                        context.Nationalities.Add(new Nationality {Title = "агулы"});
                        context.Nationalities.Add(new Nationality {Title = "адай"});
                        context.Nationalities.Add(new Nationality {Title = "аджарели"});
                        context.Nationalities.Add(new Nationality {Title = "аджарцы"});
                        context.Nationalities.Add(new Nationality {Title = "адыгейцы"});
                        context.Nationalities.Add(new Nationality {Title = "азербайджанлылар"});
                        context.Nationalities.Add(new Nationality {Title = "азербайджанцы"});
                        context.Nationalities.Add(new Nationality {Title = "айсоры"});
                        context.Nationalities.Add(new Nationality {Title = "аккинцы"});
                        context.Nationalities.Add(new Nationality {Title = "алабугатские татары"});
                        context.Nationalities.Add(new Nationality {Title = "алаи"});
                        context.Nationalities.Add(new Nationality {Title = "албанц"});
                        context.Nationalities.Add(new Nationality {Title = "алеуты"});
                        context.Nationalities.Add(new Nationality {Title = "алжирцы"});
                        context.Nationalities.Add(new Nationality {Title = "алтай-кижи"});
                        context.Nationalities.Add(new Nationality {Title = "алтайцы"});
                        context.Nationalities.Add(new Nationality {Title = "алтына куманды"});
                        context.Nationalities.Add(new Nationality {Title = "алутальу"});
                        context.Nationalities.Add(new Nationality {Title = "алюторцы"});
                        context.Nationalities.Add(new Nationality {Title = "амгун бэйенин"});
                        context.Nationalities.Add(new Nationality {Title = "американцы"});
                        context.Nationalities.Add(new Nationality {Title = "анатри"});
                        context.Nationalities.Add(new Nationality {Title = "ангагинас"});
                        context.Nationalities.Add(new Nationality {Title = "англичане"});
                        context.Nationalities.Add(new Nationality {Title = "андал"});
                        context.Nationalities.Add(new Nationality {Title = "андии"});
                        context.Nationalities.Add(new Nationality {Title = "андийц"});
                        context.Nationalities.Add(new Nationality {Title = "анкалгакку"});
                        context.Nationalities.Add(new Nationality {Title = "анкалын"});
                        context.Nationalities.Add(new Nationality {Title = "анкальын"});
                        context.Nationalities.Add(new Nationality {Title = "апокваямыл"});
                        context.Nationalities.Add(new Nationality {Title = "апсуа"});
                        context.Nationalities.Add(new Nationality {Title = "апукинцы"});
                        context.Nationalities.Add(new Nationality {Title = "араби"});
                        context.Nationalities.Add(new Nationality {Title = "арабы"});
                        context.Nationalities.Add(new Nationality {Title = "аравийцы"});
                        context.Nationalities.Add(new Nationality {Title = "арамеи"});
                        context.Nationalities.Add(new Nationality {Title = "аргын"});
                        context.Nationalities.Add(new Nationality {Title = "армяне"});
                        context.Nationalities.Add(new Nationality {Title = "арнауты"});
                        context.Nationalities.Add(new Nationality {Title = "арчи"});
                        context.Nationalities.Add(new Nationality {Title = "арчиб"});
                        context.Nationalities.Add(new Nationality {Title = "арчинцы"});
                        context.Nationalities.Add(new Nationality {Title = "аршиштиб"});
                        context.Nationalities.Add(new Nationality {Title = "асори"});
                        context.Nationalities.Add(new Nationality {Title = "ассирийцы"});
                        context.Nationalities.Add(new Nationality {Title = "ассурайя"});
                        context.Nationalities.Add(new Nationality {Title = "атали"});
                        context.Nationalities.Add(new Nationality {Title = "атурая"});
                        context.Nationalities.Add(new Nationality {Title = "аукштайты"});
                        context.Nationalities.Add(new Nationality {Title = "ауховцы"});
                        context.Nationalities.Add(new Nationality {Title = "афганцы"});
                        context.Nationalities.Add(new Nationality {Title = "ахвалал"});
                        context.Nationalities.Add(new Nationality {Title = "ахвахцы"});
                        context.Nationalities.Add(new Nationality {Title = "ахтинцы"});
                        context.Nationalities.Add(new Nationality {Title = "ашвалъ"});
                        context.Nationalities.Add(new Nationality {Title = "ашватл"});

                        #endregion

                        #region Country damp

                        context.Countries.Add(new Country {Title = "Австрия"});
                        context.Countries.Add(new Country {Title = "Андорра"});
                        context.Countries.Add(new Country {Title = "Албания"});
                        context.Countries.Add(new Country {Title = "Беларусь"});
                        context.Countries.Add(new Country {Title = "Бельгия"});
                        context.Countries.Add(new Country {Title = "Болгария"});
                        context.Countries.Add(new Country {Title = "Босния и Герцеговина"});
                        context.Countries.Add(new Country {Title = "Ватикан"});
                        context.Countries.Add(new Country {Title = "Великобритания"});
                        context.Countries.Add(new Country {Title = "Венгрия"});
                        context.Countries.Add(new Country {Title = "Германия"});
                        context.Countries.Add(new Country {Title = "Гибралтар"});
                        context.Countries.Add(new Country {Title = "Греция"});
                        context.Countries.Add(new Country {Title = "Дания"});
                        context.Countries.Add(new Country {Title = "Ирландия"});
                        context.Countries.Add(new Country {Title = "Исландия"});
                        context.Countries.Add(new Country {Title = "Испания"});
                        context.Countries.Add(new Country {Title = "Италия"});
                        context.Countries.Add(new Country {Title = "Латвия"});
                        context.Countries.Add(new Country {Title = "Литва"});
                        context.Countries.Add(new Country {Title = "Лихтенштейн"});
                        context.Countries.Add(new Country {Title = "Люксембург"});
                        context.Countries.Add(new Country {Title = "Македония"});
                        context.Countries.Add(new Country {Title = "Мальта"});
                        context.Countries.Add(new Country {Title = "Молдавия"});

                        #endregion

                        #region Sport damp

                        context.Sport.Add(new Sport
                            {
                                Title = "Бадминтон",
                                Description="Соревнования по бадминтону на летних Олимпийских играх впервые появились на летних Олимпийских играх 1992 в Барселоне и с тех пор включались в программу каждых последующих Игр. Первоначально проводились соревнования среди мужчин и женщин в одиночном и парном разрядах. На летних Олимпийских играх 1996 в Атланте впервые были проведены соревнования в смешанном разряде. В этом виде спорта разыгрываются 5 комплектов наград. До включения в программу соревнований, бадминтон являлся демонстрационным видом спорта на летних Олимпийских играх 1972 и 1988."
                            });
                        context.Sport.Add(new Sport
                            {
                                Title = "Баскетбол",
                                Description="Соревнования по баскетболу на летних Олимпийских играх впервые появились на летних Олимпийских играх 1936 в Берлине и с тех пор включались в программу каждых последующих Игр. До этого — на Играх 1904 — проводились показательные матчи баскетболистов США. Включение баскетбола в Олимпийскую программу стало возможным после создания в 1932 году Международной любительской федерации баскетбола (FIBA). Благодаря переговорам первого генерального секретаря FIBA Ренато Уильяма Джонса и генерального секретаря Комитета по проведению Игр XI Олимпиады Карла Диема на борту парома, шедшего из Стокгольма в Германию, 19 октября 1934 года берлинский Комитет на пленарном заседании одобрил включение баскетбола в программу Олимпийских игр. Решением сессии Международного олимпийского комитета (МОК) 28 февраля 1935 года в Осло баскетбол был признан олимпийским видом спорта"
                            });
                        context.Sport.Add(new Sport
                            {
                                Title = "Борьба",
                                Description="Соревнования по борьбе на летних Олимпийских играх впервые появились на летних Олимпийских играх 1896 в Афинах и с тех пор включались в программу каждых последующих Игр кроме Игр 1900 в Париже. Первые соревнования по борьбе прошли в открытой весовой категории в греко-римском стиле, на летних Олимпийских играх 1904 в Сент-Луисе было разделение на весовые категории и соревнования проводились только по вольной борьбе."
                            });                        
                        context.Sport.Add(new Sport
                            {
                                Title = "Бокс",
                                Description="Соревнования по боксу на летних Олимпийских играх впервые появились на летних Олимпийских играх 1904 в Сент-Луисе и с тех пор включались в программу каждых последующих Игр кроме Игр 1912 в Стокгольме. Соревнования проходят в нескольких весовых категориях. На летних Олимпийских играх 2012 в Лондоне впервые будут проведены соревнования среди женщин. В этом виде спорта разыгрываются 13 комплектов наград."
                            });
                        #endregion

                        context.SaveChanges();

                        #region Address damp
                        context.Locations.Add(new Location
                            {
                                Country = context.Countries.First(),
                                Title = "Баскетбольная олимпийская арена"
                            });
                        context.Locations.Add(new Location
                            {
                                Country = context.Countries.ToArray().Skip(2).First(),
                                Title = "ул. Плеханова, 24"
                            });
                        context.Locations.Add(new Location
                            {
                                Country = context.Countries.ToArray().Skip(4).First(),
                                Title = "ул. Ангарская, 8а"
                            });
                        context.Locations.Add(new Location
                            {
                                Country = context.Countries.ToArray().Skip(6).First(),
                                Title = "Калининградский пер., 7а"
                            });
                        #endregion

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}