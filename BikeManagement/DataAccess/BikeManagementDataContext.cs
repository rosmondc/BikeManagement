using BikeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeManagement.DataAccess
{
    public class BikeManagementDataContext : IdentityDbContext
    {
        public BikeManagementDataContext(DbContextOptions<BikeManagementDataContext> options)
                : base(options)
        {}

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<CustomIdentityRole> CustomIdentityRoles { get; set; }
    }
}
