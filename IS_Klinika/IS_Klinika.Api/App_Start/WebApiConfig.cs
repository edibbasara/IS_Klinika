using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;

namespace IS_Klinika.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
