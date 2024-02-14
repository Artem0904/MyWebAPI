using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<PizzeriaDbContext>
    {
        public PizzeriaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzeriaDbContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string? connectionString = config.GetConnectionString("LocalDb");
            optionsBuilder.UseSqlServer(connectionString);
            return new PizzeriaDbContext(optionsBuilder.Options);
        }
    }
}
