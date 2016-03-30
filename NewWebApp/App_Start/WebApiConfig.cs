using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using NewWebApp.Models;
using System.Web.Http;
using System.Data.Metadata.Edm;


namespace NewWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API configuration and services
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<MarketData>("MarketDatas");
            builder.EntitySet<ReportType>("ReportTypes");
            builder.EntitySet<DeliveryTime>("DeliveryTimes");
            builder.EntitySet<combineData>("LinqDatas");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
