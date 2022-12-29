using Autofac;
using reactproject.AggregatesModel.Person;
using reactproject.AggregatesModel.Product;
using reactproject.Repositories;


namespace reactproject.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<PersonModel>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<ProductModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
