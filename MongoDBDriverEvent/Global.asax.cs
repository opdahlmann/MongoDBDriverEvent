using log4net.Config;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MongoDBDriverEvent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegistrerLog4net();
        }

        private void RegistrerLog4net()
        {
            XmlConfigurator.Configure();
        }
    }
}
