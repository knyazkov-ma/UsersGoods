using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.ServiceLocation;
using UsersGoods.Web.DataBase.Migration;

namespace UsersGoods.Web
{
	public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                ViewModel.AutoMapperConfigs.AutoMapperConfig.CreateMap(cfg);

                cfg.AllowNullCollections = true;
            });
            Mapper.AssertConfigurationIsValid();

			UnityServiceLocator serviceLocator = new UnityServiceLocator(UnityConfig.Container);
			IMigrationRunner migrationRunner = serviceLocator.GetInstance<IMigrationRunner>();
			migrationRunner.Update();
		}
    }
}
