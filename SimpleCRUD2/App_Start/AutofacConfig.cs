using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace SimpleCRUD2.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var container = RegistrationModule.BuildContainer();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}