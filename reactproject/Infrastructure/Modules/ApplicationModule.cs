using Autofac;
using reactproject.AggregatesModel.CostumerInfo;
using reactproject.AggregatesModel.Order;
using reactproject.AggregatesModel.Products;
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
        }
    }
}
