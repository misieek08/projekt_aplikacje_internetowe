using Autofac;
using Autofac.Integration.Mvc;
using CodeMark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeMark.App_Start
{
    public class AutofacConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();           
            builder.RegisterControllers(Assembly.GetAssembly(typeof(MvcApplication)));
            builder.RegisterFilterProvider();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();
                    
            // Register dependencies in custom views
            //builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}
