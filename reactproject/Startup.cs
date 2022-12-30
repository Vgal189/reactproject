using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using MongoDB.Driver;
using reactproject.Infrastructure.Configuration;
using reactproject.Infrastructure.Modules;

namespace reactproject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;        
        }
        public IConfiguration Configuration { get; }
        readonly DbConfiguration configurationDb = new DbConfiguration();

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers();
            services.AddMediatR(typeof(Program));
            services.AddSingleton<MongoClient>();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddSingleton(_ => configurationDb.GetMongoDbConnectionString());

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.UseSwagger()
                .UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
