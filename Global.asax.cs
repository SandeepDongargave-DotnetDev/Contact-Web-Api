using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using ContactWebApi.BusinessLayer;
using ContactWebApi.DataAccessLayer;
using SimpleInjector.Integration.Web.Mvc;

using ContactWebApi.App_Start;
using System.Reflection;

namespace ContactWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new Container();
            container.Register<IContactDataAccesslayer, ContactDataAccessLayer>();
            container.Register<IContactBusinessLayer, ContactBusinessLayer>();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            
            DependencyResolver.SetResolver(new App_Start.SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new App_Start.SimpleInjectorDependencyResolver(container);
            




        }
    }
}
