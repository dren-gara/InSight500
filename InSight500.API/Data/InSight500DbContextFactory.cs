using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InSight500.API.Data
{
    public class InSight500DbContextFactory : IDesignTimeDbContextFactory<InSight500DbContext>
    {
        public InSight500DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<InSight500DbContext>();
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            builder.UseNpgsql(connectionString);

            return new InSight500DbContext(builder.Options);
        }
    }
}