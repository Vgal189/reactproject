using Autofac;
using MediatR;
using reactproject.Commands.Person;
using reactproject.Commands.Product;
using reactproject.Handler.Person;
using reactproject.Handler.Product;
using System.Reflection;

namespace reactproject.Infrastructure.Modules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // requests
            builder.RegisterAssemblyTypes(typeof(AddPersonRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(AddPersonRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeletePersonRequest).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequest).GetTypeInfo().Assembly);

            // handlers
            builder.RegisterAssemblyTypes(typeof(DeletePersonRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteProductRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddPersonHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddProductHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            // notification and domain


            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
        }
    }
}
