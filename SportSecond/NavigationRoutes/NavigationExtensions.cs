﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using NavigationRoutes;

namespace SportSecond.NavigationRoutes
{
    public class CompositeMvcHtmlString : IHtmlString
    {
        private readonly IEnumerable<IHtmlString> _strings;

        public CompositeMvcHtmlString(IEnumerable<IHtmlString> strings)
        {
            _strings = strings;
        }

        public string ToHtmlString()
        {
            return string.Join(string.Empty, _strings.Select(x => x.ToHtmlString()));
        }
    }

    public static class NavigationRoutes
    {
        public static List<INavigationRouteFilter> Filters = new List<INavigationRouteFilter>();
    }

    public static class NavigationViewExtensions
    {
        public static IHtmlString Navigation(this HtmlHelper helper)
        {
            return new CompositeMvcHtmlString(
                GetRoutesForCurrentRequest(RouteTable.Routes, NavigationRoutes.Filters)
                    .Select(helper.NavigationListItemRouteLink));
        }

        public static IEnumerable<NamedRoute> GetRoutesForCurrentRequest(RouteCollection routes,
                                                                         IEnumerable<INavigationRouteFilter>
                                                                             routeFilters)
        {
            List<NamedRoute> navigationRoutes = routes.OfType<NamedRoute>().Where(r => r.IsChild == false).ToList();
            INavigationRouteFilter[] navigationRouteFilters = routeFilters as INavigationRouteFilter[] ??
                                                              routeFilters.ToArray();
            if (navigationRouteFilters.Any())
            {
                foreach (NamedRoute route in navigationRoutes.ToArray())
                {
                    if (navigationRouteFilters.Any(filter => filter.ShouldRemove(route)))
                    {
                        navigationRoutes.Remove(route);
                    }
                }
            }
            return navigationRoutes;
        }

        public static MvcHtmlString NavigationListItemRouteLink(this HtmlHelper html, NamedRoute route)
        {
            var li = new TagBuilder("li")
                {
                    InnerHtml = html.RouteLink(route.DisplayName, route.Name).ToString()
                };

            if (CurrentRouteMatchesName(html, route.Name))
            {
                li.AddCssClass("active");
            }
            if (route.Children.Any())
            {
                //TODO: create a UL of child routes here.
                li.AddCssClass("dropdown");
                li.InnerHtml = "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + route.DisplayName +
                               "<b class=\"caret\"></b></a>";
                var ul = new TagBuilder("ul");
                ul.AddCssClass("dropdown-menu");

                foreach (NamedRoute child in route.Children)
                {
                    var childLi = new TagBuilder("li")
                        {
                            InnerHtml = html.RouteLink(child.DisplayName, child.Name).ToString()
                        };
                    ul.InnerHtml += childLi.ToString();
                }
                //that would mean we need to make some quick

                li.InnerHtml = "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>" + route.DisplayName +
                               " <b class='caret'></b></a>" + ul;
            }
            return MvcHtmlString.Create(li.ToString(TagRenderMode.Normal));
        }

        private static bool CurrentRouteMatchesName(HtmlHelper html, string routeName)
        {
            var namedRoute = html.ViewContext.RouteData.Route as NamedRoute;
            if (namedRoute != null)
            {
                if (string.Equals(routeName, namedRoute.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}