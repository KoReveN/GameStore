using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using GameStore.Domain.Entities;
using GameStore.WebUI.Infrastructure.Binders;

namespace GameStore.WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Добавляем специальный связыватель модели для класса Cart
            // Связывает данные из сессии. Session["Cart"]
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}