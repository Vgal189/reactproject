using Autofac;
using reactproject.Domain.AggregatesModel.Customer;
using reactproject.Domain.AggregatesModel.Orders;
using reactproject.Domain.AggregatesModel.Products;
using reactproject.Repositories;


namespace reactproject.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<CustomerInfo>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<Product>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<Order>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
