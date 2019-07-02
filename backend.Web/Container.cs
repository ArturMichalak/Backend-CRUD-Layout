using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using backend.Repositories;
using backend.Interfaces;
using backend.Entities;
using backend.Common;

namespace backend.Web
{
    public class Container
    {
        public IContainer Get => container;

        #region container initializer
        public Container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Dependencies(builder);
            container = builder.Build();
        }
        #endregion

        private void Dependencies(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType<DriverRepository>().As<IRepository<Driver>>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IRepository<Order>>().InstancePerLifetimeScope();
            builder.RegisterType<RouteRepository>().As<IRepository<Route>>().InstancePerLifetimeScope();
            builder.RegisterType<TruckRepository>().As<IRepository<Truck>>().InstancePerLifetimeScope();
            builder.RegisterType<WorkingTimeLogRepository>().As<IRepository<WorkingTimeLog>>().InstancePerLifetimeScope();
            builder.RegisterType<WorkingTime>().As<ICommand<WorkingTimeLog>>().InstancePerLifetimeScope();
            builder.RegisterType<RoutePointRepository>().As<IRepository<RoutePoint>>().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
        }

        #region private fields
        private readonly IContainer container;
        #endregion
    }
}