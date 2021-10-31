﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuddyHub
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //     name: "Login",
            //     url: "Login",
            //     defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            // );
            // routes.MapRoute(
            //    name: "Registration",
            //    url: "Registration",
            //    defaults: new { controller = "User", action = "Registration", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Like",
                url: "Post/LikeOnPost/{Username}/{PostId}",
                defaults: new { controller = "Post", action = "LikeOnPost", Username = UrlParameter.Optional, PostId = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
         );
        }
    }
}
