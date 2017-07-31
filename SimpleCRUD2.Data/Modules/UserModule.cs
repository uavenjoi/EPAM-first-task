using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SimpleCRUD2.Data.Repositories;

namespace SimpleCRUD2.Data.Modules
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            base.Load(builder);
        }
    }
}
