using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace SimpleCRUD2.Data.Modules
{
    public class RegistrationModule
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<UserModule>();

            return builder.Build();
        }
    }
}
