using Autofac;
using SimpleCRUD2.Data;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Repositories;

namespace SimpleCRUD2.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();

            base.Load(builder);
        }
    }
}