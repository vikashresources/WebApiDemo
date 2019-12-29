using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Diagnostics;
using WebApiDemo.Models;
using System.Net.Http.Headers;

namespace WebApiDemo
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{action}/{id}",
             defaults: new { id = RouteParameter.Optional }
        );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
           // config.Formatters.JsonFormatter.MediaTypeMappings.Add(new CustomMediaTypeMapping(new MediaTypeHeaderValue("application/json")));

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            foreach (var formatter in config.Formatters)
            {
                Trace.WriteLine(formatter.GetType().Name);
                Trace.WriteLine("\tCanReadType: " + formatter.CanReadType(typeof(Employee)));
                Trace.WriteLine("\tCanWriteType: " + formatter.CanWriteType(typeof(Employee)));
                Trace.WriteLine("\tBase: " + formatter.GetType().BaseType.Name);
                Trace.WriteLine("\tMedia Types: " + String.Join(", ", formatter.SupportedMediaTypes));
            }
        }
    }
}
