using BikeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PlaneBooking.DataAccess
{
    public class BikeManagementDataContextFactory : IDesignTimeDbContextFactory<BikeManagementDataContext>
    {
        public BikeManagementDataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var builder = new DbContextOptionsBuilder<BikeManagementDataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new BikeManagementDataContext(builder.Options);
        }
    }
}
