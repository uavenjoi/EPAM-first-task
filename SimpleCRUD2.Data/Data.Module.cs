using Autofac;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserContext>().As<IContext>();

            base.Load(builder);
        }
    }
}
