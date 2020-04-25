using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SapoLoyalty.Controllers;
using SapoLoyalty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace SapoLoyalty
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var apiconfig = GlobalConfiguration.Configuration;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //Register Types
            builder.RegisterGeneric(typeof(SQLDataService<>)).As(typeof(ISQLDataService<>)).InstancePerLifetimeScope().InstancePerHttpRequest();
            builder.RegisterType<LoyaltyCardService>().As<ILoyaltyCardService>().InstancePerHttpRequest().InstancePerApiRequest().InstancePerLifetimeScope()
                .InstancePerHttpRequest();
            builder.RegisterType<LoyaltyCardTypeService>().As<ILoyaltyCardTypeService>().InstancePerHttpRequest().InstancePerApiRequest().InstancePerLifetimeScope()
               .InstancePerHttpRequest();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>().InstancePerHttpRequest().InstancePerApiRequest().InstancePerLifetimeScope()
               .InstancePerHttpRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            apiconfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
