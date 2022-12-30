using Autofac;
using MediatR;
using reactproject.Commands.Costumer;
using reactproject.Commands.Products;
using reactproject.Handler.Costumer;
using reactproject.Handler.Products;
using System.Reflection;

namespace reactproject.Infrastructure.Modules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // requests
            builder.RegisterAssemblyTypes(typeof(AddCustomerInfoRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(AddCustomerInfoRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeleteCustomerInfoRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequest).GetTypeInfo().Assembly);

            // handlers
            builder.RegisterAssemblyTypes(typeof(DeleteCostumerInfoHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddCostumerInfoHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddProductHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            // notification and domain


            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
        }
    }
}
