using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApplication14
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Controller",
                routeTemplate: "api/{controller}"
            );
            /*config.Routes.MapHttpRoute(
                name: "ControllerWithget",
                routeTemplate: "api/{controller}",
                defaults: new {action="Get"},
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Get)}
            );
            config.Routes.MapHttpRoute(
                name: "ControllerWithpost",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );*/
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^\d+$" }
            ) ;

            config.Routes.MapHttpRoute(
                name: "Action",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Action with id",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^\d+$" }
            );
            config.Routes.MapHttpRoute(
                name: "Action with name",
                routeTemplate: "api/{controller}/{action}/{value}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
