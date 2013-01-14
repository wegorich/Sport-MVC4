using System.Web.Routing;
using SportSecond.Controllers;
using SportSecond.NavigationRoutes;

namespace SportSecond.App_Start
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>("Мероприятия", c => c.Index());
            routes.MapNavigationRoute<HomeController>("Команды", c => c.Teams());
            routes.MapNavigationRoute<HomeController>("Спортсмены", c => c.Sportsmans());

            routes.MapNavigationRoute<ExampleLayoutsController>("Админка", c => c.Starter())
                  .AddChildRoute<EventController>("Мероприятия", c => c.Index())
                  .AddChildRoute<TeamController>("Команды", c => c.Index())
                  .AddChildRoute<SportsmanController>("Спортсмены", c => c.Index())
                  .AddChildRoute<LocationController>("Адреса", c => c.Index())
                  .AddChildRoute<SportController>("Виды спорта", c => c.Index())
                  .AddChildRoute<CountryController>("Страны", c => c.Index())
                ;
        }
    }
}