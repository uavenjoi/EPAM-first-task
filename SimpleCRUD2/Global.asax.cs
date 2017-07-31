using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleCRUD2.App_Start;

namespace SimpleCRUD2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
