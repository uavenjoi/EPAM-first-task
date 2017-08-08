using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleCRUD2.App_Start;
using SimpleCRUD2.Loggers;

namespace SimpleCRUD2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            Logger.InitLogger();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
