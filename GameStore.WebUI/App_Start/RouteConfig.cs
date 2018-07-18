using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //	"/"   Выводит первую страницу списка товаров всех категорий
            routes.MapRoute(null, "",
                new
                {
                    controller = "Game",
                    action = "List",
                    category = (string)null,
                    page = 1
                });

            // "/Page2"	Выводит указанную страницу(в этом случае страницу 2), отображая товары всех категорий
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Game", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
                );

            // "/Симулятор"	Отображает первую страницу элементов указанной категории (в этом случае игры в разделе "Симуляторы")
            routes.MapRoute(
                null,
                "{category}",
                new { controller = "Game", action ="List", page = 1}
                );

            // "/Симулятор/Page2"     Отображает заданную страницу (в этом случае страницу 2) элементов указанной категории (Симулятор)
            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new { controller = "Game", action = "List" },
                new { page = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}"
                );
            //  defaults: new { controller = "Game", action = "List", id = UrlParameter.Optional }

        }
    }
}
