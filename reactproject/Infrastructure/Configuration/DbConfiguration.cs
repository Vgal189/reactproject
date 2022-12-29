namespace reactproject.Infrastructure.Configuration
{
    public class DbConfiguration
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        private readonly IConfiguration _config;

        public DbConfiguration()
        {
            _config = config;
        }


        public string GetMongoDbConnectionString()
        {
            return _config.GetValue<string>("ConnectionStrings:MongoDb");
        }

    }

}
