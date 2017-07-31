using Autofac;
using Autofac.Integration.Mvc;
using SimpleCRUD2.Data;

namespace SimpleCRUD2
{
    public class RegistrationModule
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<SimpleCRUD2.Modules.DataModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            return builder.Build();
        }
    }
}
