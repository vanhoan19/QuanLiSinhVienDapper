using Castle.MicroKernel.Registration;
using Castle.Windsor;
using QuanLiSinhVienDapper.Controllers;
using QuanLiSinhVienDapper.Repository;
using QuanLiSinhVienDapper.WindsorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QuanLiSinhVienDapper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<SinhVienController>().LifeStyle.Transient);
            container.Register(Component.For<MonHocController>().LifeStyle.Transient);
            container.Register(Component.For<KetQuaController>().LifeStyle.Transient);
            container.Register(Component.For<StudentRepository>());
            container.Register(Component.For<MonHocRepository>());
            container.Register(Component.For<KetQuaRepository>());

            // Đăng ký Controller Factory sử dụng Windsor
            var controllerFactory = new WindsorControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
