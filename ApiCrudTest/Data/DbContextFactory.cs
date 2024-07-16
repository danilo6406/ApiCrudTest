using Microsoft.EntityFrameworkCore;

namespace ApiCrudTest.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApiTestDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiTestDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ApiTestDbConnection"));
            return new ApiTestDbContext(optionsBuilder.Options);
        }
    }
}
