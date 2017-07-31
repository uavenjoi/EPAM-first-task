using Autofac;
using Autofac.Integration.Mvc;

namespace SimpleCRUD2
{
    public class RegistrationModule
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<SimpleCRUD2.Modules.DataModule>();
            builder.RegisterModule<SimpleCRUD2.Data.DataModule>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            return builder.Build();
        }
    }
}
