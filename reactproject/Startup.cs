using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using reactproject.Domain.Core;
using reactproject.Identity.Services;
using reactproject.Infrastructure.Configuration;
using reactproject.Infrastructure.Modules;
using System.Text;

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
        readonly TokenService tokenService = new TokenService();

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddControllers();
            services.AddMediatR(typeof(Program));
            services.AddSingleton<MongoClient>();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddSingleton(_ => configurationDb.GetMongoDbConnectionString());
            var key = Encoding.ASCII.GetBytes(tokenService.GetSecret());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(ConfigureAuthorizationPolicies);
            services.AddTransient<TokenService>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, ObjectId>
                (configurationDb.GetMongoDbConnectionString(), "simple_db");

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureAuthorizationPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("CreatePolicy", policy =>
                policy.RequireRole("Admin", "Collaborator"));
            options.AddPolicy("ReadPolicy", policy =>
                policy.RequireRole("Admin", "Manager", "Collaborator", "Reader"));
            options.AddPolicy("UpdatePolicy", policy =>
                policy.RequireRole("Admin", "Collaborator"));
            options.AddPolicy("DeletePolicy", policy =>
                policy.RequireRole("Admin", "Collaborator"));
            options.AddPolicy("Administration", policy =>
                policy.RequireRole("Admin"));
            options.AddPolicy("Management", policy =>
                policy.RequireRole("Admin", "Manager"));
            options.AddPolicy("Development", policy =>
                policy.RequireRole("Admin", "Collaborator"));
            options.AddPolicy("Organization", policy =>
                policy.RequireRole("Admin", "Manager", "Collaborator"));
        }
    }
}
