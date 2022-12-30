using Autofac;
using MediatR;
using reactproject.Commands.Customer;
using reactproject.Commands.Orders;
using reactproject.Commands.Products;
using reactproject.Handler.Customer;
using reactproject.Handler.Orders;
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
            builder.RegisterAssemblyTypes(typeof(AddOrderRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeleteCustomerInfoRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(UpdateProductRequest).GetTypeInfo().Assembly);

            // handlers
            builder.RegisterAssemblyTypes(typeof(DeleteCustomerInfoHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteOrderRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddCustomerInfoHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddProductRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddOrderRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateProductRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // notification and domain


            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
        }
    }
}
